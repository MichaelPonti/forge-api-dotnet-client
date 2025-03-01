/* 
 * Forge SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk
 * cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Contact: forge.help@autodesk.com
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Autodesk.Forge.Sample {

	class Program {

		#region Enums & Consts
		public enum Region {
			US,
			EMEA
		};

		#endregion

		#region Fields & Properties
		private static string FORGE_CLIENT_ID { get; set; } = "";
		private static string FORGE_CLIENT_SECRET { get; set; } = "";
		private static readonly Scope [] SCOPES = new Scope [] {
			Scope.DataRead, Scope.DataWrite, Scope.DataCreate, Scope.DataSearch,
			Scope.BucketCreate, Scope.BucketRead, Scope.BucketUpdate, Scope.BucketDelete
		};
		protected static string BucketKey { get { return ("forge_sample_" + FORGE_CLIENT_ID.ToLower () + "-" + region.ToString ().ToLower ()); } }
		protected static string ObjectKey { get { return ("test.nwd"); } }

		protected static Region region { get; set; } = Region.US;


		protected static BucketsApi BucketAPI = new BucketsApi ();
		protected static ObjectsApi ObjectsAPI = new ObjectsApi ();
		protected static DerivativesApi USDerivativesAPI = new DerivativesApi (/*(Configuration)null, false*/);
		protected static DerivativesApi EMEADerivativesAPI = new DerivativesApi ((Configuration)null, true);
		protected static DerivativesApi DerivativesAPI = USDerivativesAPI; // defaults to US
		protected static DerivativesApi DerivativesAPIAutoRegion { get { return (region == Region.US ? USDerivativesAPI : EMEADerivativesAPI); } }

		#endregion

		#region Forge
		private async static Task<ApiResponse<dynamic>> oauthExecAsync () {
			try {
				TwoLeggedApi _twoLeggedApi = new TwoLeggedApi ();
				ApiResponse<dynamic> bearer = await _twoLeggedApi.AuthenticateAsyncWithHttpInfo (FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, SCOPES);
				httpErrorHandler (bearer, "Failed to get your token");

				BucketAPI.Configuration.Bearer = new Bearer (bearer);
				ObjectsAPI.Configuration.Bearer = new Bearer (bearer);
				USDerivativesAPI.Configuration.Bearer = new Bearer (bearer);
				EMEADerivativesAPI.Configuration.Bearer = new Bearer (bearer);

				return (bearer);
			} catch ( Exception ex ) {
				Console.WriteLine ("Exception when calling TwoLeggedApi.AuthenticateAsyncWithHttpInfo : " + ex.Message);
				return (null);
			}
		}

		private static dynamic GetBucketDetails () {
			try {
				Console.WriteLine ("**** Getting bucket details for: " + BucketKey);
				dynamic response = BucketAPI.GetBucketDetails (BucketKey);
				return (response);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed getting bucket details for : " + BucketKey);
				return (null);
			}
		}

		private static dynamic CreateBucket () {
			try {
				Console.WriteLine ("**** Creating bucket: " + BucketKey);
				PostBucketsPayload.PolicyKeyEnum bucketType = PostBucketsPayload.PolicyKeyEnum.Persistent;
				PostBucketsPayload payload = new PostBucketsPayload (BucketKey, null, bucketType);
				dynamic response = BucketAPI.CreateBucket (payload, region.ToString ());
				return (response);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed creating bucket: " + BucketKey);
				return (null);
			}
		}

		private static bool CreateBucketIfNotExist () {
			dynamic response = GetBucketDetails ();
			if ( response == null )
				response = CreateBucket ();
			if ( response == null )
				Console.WriteLine ("*** Failed to create bucket: " + BucketKey);
			return (response != null);
		}

		private static bool DeleteBucket () {
			try {
				Console.WriteLine ("**** Deleting bucket: " + BucketKey);
				BucketAPI.DeleteBucket (BucketKey);
				return (true);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed deleting bucket: " + BucketKey);
				return (false);
			}
		}

		private static dynamic GetObjectDetails () {
			try {
				Console.WriteLine ("**** Getting object details: " + ObjectKey);
				dynamic response = ObjectsAPI.GetObjectDetails (BucketKey, ObjectKey);
				return (response);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed getting object details: " + ObjectKey);
				return (null);
			}
		}

		private static string UploadObject2Bucket () {
			try {
				Console.WriteLine ("**** Uploading object: " + ObjectKey);
				using ( StreamReader streamReader = new StreamReader (ObjectKey) ) {
					dynamic response = ObjectsAPI.UploadObjectWithHttpInfo (
						BucketKey,
						ObjectKey,
						(int)streamReader.BaseStream.Length,
						streamReader.BaseStream,
						"application/octet-stream"
					);
					httpErrorHandler (response, "Failed to upload file");
					return (response.Data ["objectId"]);
				}
			} catch ( Exception ex ) {
				Console.WriteLine ("**** Failed to upload file - " + ex.Message);
				return (null);
			}
		}

		private static string UploadSampleFile () {
			dynamic response = GetObjectDetails ();
			if ( response != null )
				return (response.objectId);
			response = UploadObject2Bucket ();
			if ( response == null ) {
				Console.WriteLine ("*** Failed to upload sample file: " + ObjectKey);
				return (null);
			}
			return (response);
		}

		private static bool DeleteSampleFile () {
			try {
				Console.WriteLine ("**** Deleting object: " + ObjectKey);
				ObjectsAPI.DeleteObject (BucketKey, ObjectKey);
				return (true);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed deleting object: " + ObjectKey);
				return (false);
			}
		}

		private async static Task<bool> Translate2Svf (string urn, JobPayloadDestination.RegionEnum targetRegion = JobPayloadDestination.RegionEnum.US) {
			try {
				Console.WriteLine ("**** Requesting SVF translation for: " + urn);
				JobPayloadInput jobInput = new JobPayloadInput (urn);
				JobPayloadOutput jobOutput = new JobPayloadOutput (
					new List<JobPayloadItem> (
						new JobPayloadItem [] {
								new JobPayloadItem (
									JobPayloadItem.TypeEnum.Svf,
									new List<JobPayloadItem.ViewsEnum> (
										new JobPayloadItem.ViewsEnum [] {
											JobPayloadItem.ViewsEnum._2d, JobPayloadItem.ViewsEnum._3d
										}
									),
									null
								)
						}
					),
					new JobPayloadDestination (targetRegion)
				);
				JobPayload job = new JobPayload (jobInput, jobOutput);
				bool bForce = true;
				ApiResponse<dynamic> response = await DerivativesAPI.TranslateAsyncWithHttpInfo (job, bForce);
				httpErrorHandler (response, "Failed to register file for SVF translation");
				return (true);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed to register file for SVF translation");
				return (false);
			}
		}

		private async static Task<bool> Translate2Svf2 (string urn, JobPayloadDestination.RegionEnum targetRegion = JobPayloadDestination.RegionEnum.US) {
			try {
				Console.WriteLine ("**** Requesting SVF2 translation for: " + urn);
				JobPayloadInput jobInput = new JobPayloadInput (urn);
				JobPayloadOutput jobOutput = new JobPayloadOutput (
					new List<JobPayloadItem> (
						new JobPayloadItem [] {
								new JobPayloadItem (
									JobPayloadItem.TypeEnum.Svf2,
									new List<JobPayloadItem.ViewsEnum> (
										new JobPayloadItem.ViewsEnum [] {
											JobPayloadItem.ViewsEnum._2d, JobPayloadItem.ViewsEnum._3d
										}
									),
									null
								)
						}
					),
					new JobPayloadDestination (targetRegion)
				);
				JobPayload job = new JobPayload (jobInput, jobOutput);
				bool bForce = true;
				ApiResponse<dynamic> response = await DerivativesAPI.TranslateAsyncWithHttpInfo (job, bForce);
				httpErrorHandler (response, "Failed to register file for SVF2 translation");
				return (true);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed to register file for SVF2 translation");
				return (false);
			}
		}

		private async static Task<bool> Translate2Obj (string urn, string guid, JobObjOutputPayloadAdvanced.UnitEnum unit = JobObjOutputPayloadAdvanced.UnitEnum.Meter, JobPayloadDestination.RegionEnum targetRegion = JobPayloadDestination.RegionEnum.US) {
			try {
				Console.WriteLine ("**** Requesting OBJ translation for: " + urn);
				JobPayloadInput jobInput = new JobPayloadInput (urn);
				JobPayloadOutput jobOutput = new JobPayloadOutput (
					new List<JobPayloadItem> (
						new JobPayloadItem [] {
								new JobPayloadItem (
									JobPayloadItem.TypeEnum.Obj,
									null,
									//new JobObjOutputPayloadAdvanced (null, guid, new List<int> () { -1 }, unit) // all
									new JobObjOutputPayloadAdvanced (null, guid, new List<int> () { 1526, 1527 }, unit)
								)
						}
					),
					new JobPayloadDestination (targetRegion)
				);
				JobPayload job = new JobPayload (jobInput, jobOutput);
				bool bForce = true;
				ApiResponse<dynamic> response = await DerivativesAPI.TranslateAsyncWithHttpInfo (job, bForce);
				httpErrorHandler (response, "Failed to register file for OBJ translation");
				return (true);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed to register file for OBJ translation");
				return (false);
			}
		}

		private async static Task<bool> Translate2Stl (string urn, string guid, JobObjOutputPayloadAdvanced.UnitEnum unit = JobObjOutputPayloadAdvanced.UnitEnum.Meter, JobPayloadDestination.RegionEnum targetRegion = JobPayloadDestination.RegionEnum.US) {
			try {
				Console.WriteLine ("**** Requesting STL translation for: " + urn);
				JobPayloadInput jobInput = new JobPayloadInput (urn);
				JobPayloadOutput jobOutput = new JobPayloadOutput (
					new List<JobPayloadItem> (
						new JobPayloadItem [] {
								new JobPayloadItem (
									JobPayloadItem.TypeEnum.Stl,
									null,
									new JobStlOutputPayloadAdvanced (JobStlOutputPayloadAdvanced.FormatEnum.Ascii, true, JobStlOutputPayloadAdvanced.ExportFileStructureEnum.Single)
								)
						}
					),
					new JobPayloadDestination (targetRegion)
				);
				JobPayload job = new JobPayload (jobInput, jobOutput);
				bool bForce = true;
				ApiResponse<dynamic> response = await DerivativesAPI.TranslateAsyncWithHttpInfo (job, bForce);
				httpErrorHandler (response, "Failed to register file for STL translation");
				return (true);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed to register file for STL translation");
				return (false);
			}
		}

		private static bool DeleteManifest (string urn) {
			try {
				Console.WriteLine ("**** Deleting manifest for: " + urn);
				DerivativesAPI.DeleteManifest (urn);
				return (true);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed deleting manifest: " + urn);
				return (false);
			}
		}

		private static dynamic GetManifest (string urn) {
			try {
				Console.WriteLine ("**** Getting Manifest of: " + urn);
				dynamic response = DerivativesAPI.GetManifest (urn);
				return (response);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed getting Manifest of: " + urn);
				return (null);
			}
		}

		private static dynamic GetMetadata (string urn) {
			try {
				Console.WriteLine ("**** Getting Metadata of: " + urn);
				dynamic response = DerivativesAPI.GetMetadata (urn);
				return (response);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed getting Metadata of: " + urn);
				return (null);
			}
		}

		private static IDictionary<string, string> GetDerivativesManifestHeaders (string urn, string derivativesUrn) {
			try {
				Console.WriteLine ("**** Getting DerivativesManifest Headers of: " + derivativesUrn);
				dynamic response = DerivativesAPI.GetDerivativeManifestHeaders (urn, derivativesUrn);
				return (response);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed getting DerivativesManifest Headers of: " + derivativesUrn);
				return (null);
			}
		}

		private static dynamic GetDerivativesManifest (string urn, string derivativesUrn) {
			try {
				Console.WriteLine ("**** Getting DerivativesManifest of: " + derivativesUrn);
				dynamic response = DerivativesAPI.GetDerivativeManifest (urn, derivativesUrn);
				return (response);
			} catch ( Exception ) {
				Console.WriteLine ("**** Failed getting DerivativesManifest of: " + derivativesUrn);
				return (null);
			}
		}

		private static dynamic FindDerivativesNode (string outputType, dynamic manifest) {
			if ( manifest == null )
				return (null);
			for ( int i = 0 ; i < manifest.derivatives.Count ; i++ ) {
				dynamic derivatives = manifest.derivatives [i];
				if ( derivatives.outputType == outputType )
					return (derivatives);
			}
			return (null);
		}

		private static string FindDerivativesNodeStatus (string outputType, dynamic manifest) {
			if ( manifest == null )
				return (null);
			dynamic derivatives = FindDerivativesNode (outputType, manifest);
			if ( derivatives != null )
				return (derivatives.progress);
			return (null);
		}

		#endregion

		#region US / EMEA processes

		static async Task CleanUP (string urn, DerivativesApi endpoint, Region storage = Region.US) {
			Console.WriteLine ("Running Endpoint: " + (endpoint.RegionIsEMEA ? "EMEA" : "US") + " server - Storage: " + storage.ToString ());
			region = storage;
			DerivativesAPI = endpoint;

			dynamic response = await oauthExecAsync ();
			if ( response == null )
				return;

			DeleteManifest (urn);
			DeleteBucket (); // This deletes the file(s) as well
		}

		static async Task<string> TryWorkflow (DerivativesApi endpoint, Region storage = Region.US, JobPayloadDestination.RegionEnum derivativeRegion = JobPayloadDestination.RegionEnum.US) {
			Console.WriteLine ("Running Endpoint: " + (endpoint.RegionIsEMEA ? "EMEA" : "US") + " server - Storage: " + storage.ToString () + " - Derivative Region: " + derivativeRegion.ToString ());
			region = storage;
			DerivativesAPI = endpoint;

			dynamic response = await oauthExecAsync ();
			if ( response == null )
				return (null);
			response = CreateBucketIfNotExist ();
			if ( !response )
				return (null);
			//DeleteSampleFile();
			response = UploadSampleFile ();
			if ( response == null )
				return (null);
			string urn = SafeBase64Encode (response);

			//DeleteManifest (urn);
			response = GetManifest (urn);
			if ( response != null )
				Console.WriteLine (response.ToString ());
			string found = FindDerivativesNodeStatus ("svf2", response);
			if ( found == null ) {
				response = await Translate2Svf2 (urn, derivativeRegion);
				if ( !response )
					return (null);
				Console.WriteLine ("Please wait for SVF2 translation to complete");
				return (null);
			} else if ( found != "complete" ) {
				Console.WriteLine ("Translation Failed or Still translating...");
				return (null);
			}

			found = FindDerivativesNodeStatus ("obj", response);
			string guid = null;
			if ( found == null ) {
				response = GetMetadata (urn);
				if ( response == null )
					return (urn);
				guid = response.data.metadata [0].guid;

				response = await Translate2Obj (urn, guid, JobObjOutputPayloadAdvanced.UnitEnum.Meter, derivativeRegion);
				if ( !response )
					return (urn);
				Console.WriteLine ("Please wait for OBJ translation to complete");
				return (urn);
			} else if ( found != "complete" ) {
				Console.WriteLine ("Translation Failed or Still translating...");
				return (urn);
			}

			dynamic node = FindDerivativesNode ("obj", response);

			response = GetMetadata (urn);
			if ( response == null )
				return (urn);
			guid = response.data.metadata [0].guid;

			for ( int i = 0 ; i < node.children.Count ; i++ ) {
				dynamic elt = node.children [i];
				if ( elt.type != "resource" || elt.status != "success" || elt.modelGuid != guid || elt.role != "obj" )
					continue;
				Console.WriteLine (elt.urn);

				IDictionary<string, string> headers = GetDerivativesManifestHeaders (urn, elt.urn);
				Console.WriteLine ("\t size: " + headers ["Content-Length"]);

				System.IO.MemoryStream stream = GetDerivativesManifest (urn, elt.urn);
				if ( stream == null )
					continue;
				stream.Seek (0, SeekOrigin.Begin);
				string name = elt.urn.Substring (elt.urn.LastIndexOf ('/') + 1);
				File.WriteAllBytes (name, stream.ToArray ());
			}

			Console.WriteLine ("Done");
			return (urn);
		}

		#endregion

		#region Utils
		private static void readFromEnvOrSettings (string name, Action<string> setOutput) {
			string st = Environment.GetEnvironmentVariable (name);
			if ( !string.IsNullOrEmpty (st) )
				setOutput (st);
		}

		private static bool readConfigFromEnvOrSettings () {
			readFromEnvOrSettings ("FORGE_CLIENT_ID", value => FORGE_CLIENT_ID = value);
			readFromEnvOrSettings ("FORGE_CLIENT_SECRET", value => FORGE_CLIENT_SECRET = value);
			//readFromEnvOrSettings("PORT", value => PORT = value);
			//readFromEnvOrSettings("FORGE_CALLBACK", value => FORGE_CALLBACK = value);
			return (true);
		}

		public static bool httpErrorHandler (ApiResponse<dynamic> response, string msg = "", bool bThrowException = true) {
			if ( response.StatusCode < 200 || response.StatusCode >= 300 ) {
				if ( bThrowException )
					throw new Exception (msg + " (HTTP " + response.StatusCode + ")");
				return (true);
			}
			return (false);
		}

		private static readonly char [] padding = { '=' };
		public static string SafeBase64Encode (string plainText) {
			var plainTextBytes = System.Text.Encoding.UTF8.GetBytes (plainText);
			return (System.Convert.ToBase64String (plainTextBytes)
				.TrimEnd (padding).Replace ('+', '-').Replace ('/', '_')
			);
		}

		public static string SafeBase64Decode (string base64EncodedData) {
			string st = base64EncodedData.Replace ('_', '/').Replace ('-', '+');
			switch ( base64EncodedData.Length % 4 ) {
				case 2:
					st += "==";
					break;
				case 3:
					st += "=";
					break;
			}
			var base64EncodedBytes = System.Convert.FromBase64String (st);
			return (System.Text.Encoding.UTF8.GetString (base64EncodedBytes));
		}

		public static string BuildURN (string bucketKey, string objectKey) {
			return (SafeBase64Encode ($"urn:adsk.objects:os.object:{bucketKey}/{objectKey}"));
		}

		#endregion

		// app cleanup US US
		// app US US US

		static async Task Main (string [] args) {
			Console.WriteLine ("Hello World!");
			//region = Region.US; // Done while initializing
			//DerivativesAPI = USDerivativesAPI;

			readConfigFromEnvOrSettings ();
			string urn = BuildURN (BucketKey, ObjectKey);

			if ( args [0] == "cleanup" ) {
				try {
					Region endpoint = Enum.Parse<Region> (args [1], true);
					Region storage = Enum.Parse<Region> (args [2], true);

					await CleanUP (
						urn,
						endpoint == Region.US ? USDerivativesAPI : EMEADerivativesAPI,
						storage
					);
				} catch ( Exception ) { }

			} else {
				try {
					Region endpoint = Enum.Parse<Region> (args [0], true);
					Region storage = Enum.Parse<Region> (args [1], true);
					JobPayloadDestination.RegionEnum target = Enum.Parse<JobPayloadDestination.RegionEnum> (args [2], true);

					urn = await TryWorkflow (
						endpoint == Region.US ? USDerivativesAPI : EMEADerivativesAPI,
						storage,
						target
					);
				} catch ( Exception ) { }
			}
			Console.WriteLine ("Done");
		}

	}

}
