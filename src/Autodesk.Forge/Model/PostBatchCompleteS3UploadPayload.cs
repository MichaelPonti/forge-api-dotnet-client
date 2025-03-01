/* 
 * Forge SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *

 * Contact: forge.help@autodesk.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
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
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Autodesk.Forge.Model {

	/// <summary>
	/// Post PostBatchCompleteS3UploadPayloadItem Payload Body Structure
	/// </summary>
	[DataContract]
	public partial class PostBatchCompleteS3UploadPayloadItem : IEquatable<PostBatchCompleteS3UploadPayloadItem> {

		[DataMember (Name = "objectKey", EmitDefaultValue = false)]
		public string objectKey { get; set; }

		[DataMember (Name = "uploadKey", EmitDefaultValue = false)]
		public string uploadKey { get; set; }

		[DataMember (Name = "size", EmitDefaultValue = false)]
		public long? size { get; set; }

		[DataMember (Name = "eTags", EmitDefaultValue = false)]
		public List<String> eTags { get; set; }

		[DataMember (Name = "x-ads-meta-Content-Type", EmitDefaultValue = false)]
		public string xAdsMetaContentType { get; set; }

		[DataMember (Name = "x-ads-meta-Content-Disposition", EmitDefaultValue = false)]
		public string xAdsMetaContentDisposition { get; set; }

		[DataMember (Name = "x-ads-meta-Content-Encoding", EmitDefaultValue = false)]
		public string xAdsMetaContentEncoding { get; set; }

		[DataMember (Name = "x-ads-meta-Cache-Control", EmitDefaultValue = false)]
		public string xAdsMetaCacheControl { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PostBatchCompleteS3UploadPayloadItem" /> class.
		/// </summary>
		[JsonConstructorAttribute]
		protected PostBatchCompleteS3UploadPayloadItem () { }

		public PostBatchCompleteS3UploadPayloadItem (
			string objectKey, string uploadKey, long? size, List<string> eTags = null,
			string xAdsMetaContentType = null,
			string xAdsMetaContentDisposition = null,
			string xAdsMetaContentEncoding = null,
			string xAdsMetaCacheControl = null
		) {
			if ( String.IsNullOrEmpty (objectKey) )
				throw new InvalidDataException ("objectKey is a required property for PostBatchCompleteS3UploadPayloadItem and cannot be null or empty");
			if ( String.IsNullOrEmpty (uploadKey) )
				throw new InvalidDataException ("uploadKey is a required property for PostBatchCompleteS3UploadPayloadItem and cannot be null or empty");
			this.objectKey = objectKey;
			this.uploadKey = uploadKey;
			this.size = size;
			this.eTags = eTags;
			this.xAdsMetaContentType = xAdsMetaContentType;
			this.xAdsMetaContentDisposition = xAdsMetaContentDisposition;
			this.xAdsMetaContentEncoding = xAdsMetaContentEncoding;
			this.xAdsMetaCacheControl = xAdsMetaCacheControl;
		}

		public override string ToString () {
			var sb = new StringBuilder ();
			sb.Append ("class PostBatchCompleteS3UploadPayloadItem {\n");
			sb.Append ("  objectKey: ").Append (objectKey).Append ("\n");
			sb.Append ("  uploadKey: ").Append (uploadKey).Append ("\n");
			sb.Append ("  size: ").Append (size).Append ("\n");
			sb.Append ("  eTags: ").Append (eTags).Append ("\n");
			sb.Append ("  xAdsMetaContentType: ").Append (xAdsMetaContentType).Append ("\n");
			sb.Append ("  xAdsMetaContentDisposition: ").Append (xAdsMetaContentDisposition).Append ("\n");
			sb.Append ("  xAdsMetaContentEncoding: ").Append (xAdsMetaContentEncoding).Append ("\n");
			sb.Append ("  xAdsMetaCacheControl: ").Append (xAdsMetaCacheControl).Append ("\n");
			sb.Append ("}\n");
			return (sb.ToString ());
		}

		public string ToJson () {
			return (JsonConvert.SerializeObject (this, Formatting.Indented));
		}

		public override bool Equals (object obj) {
			// credit: http://stackoverflow.com/a/10454552/677735
			return (this.Equals (obj as PostBatchCompleteS3UploadPayloadItem));
		}

		/// <summary>
		/// Returns true if PostBatchCompleteS3UploadPayloadItem instances are equal
		/// </summary>
		/// <param name="other">Instance of PostBatchCompleteS3UploadPayloadItem to be compared</param>
		/// <returns>Boolean</returns>
		public bool Equals (PostBatchCompleteS3UploadPayloadItem other) {
			// credit: http://stackoverflow.com/a/10454552/677735
			if ( other == null )
				return (false);

			return (
				(
					this.objectKey == other.objectKey ||
					this.objectKey != null &&
					this.objectKey.Equals (other.objectKey)
				)
				&& 
				(
					this.uploadKey == other.uploadKey ||
					this.uploadKey != null &&
					this.uploadKey.Equals (other.uploadKey)
				)
				&&
				(
					this.size == other.size ||
					this.size != null &&
					this.size.Equals (other.size)
				)
				&&
				(
					this.eTags == other.eTags ||
					this.eTags != null &&
					this.eTags.SequenceEqual (other.eTags)
				)
				&&
				(
					this.xAdsMetaContentType == other.xAdsMetaContentType ||
					this.xAdsMetaContentType != null &&
					this.xAdsMetaContentType.Equals (other.xAdsMetaContentType)
				)
				&&
				(
					this.xAdsMetaContentDisposition == other.xAdsMetaContentDisposition ||
					this.xAdsMetaContentDisposition != null &&
					this.xAdsMetaContentDisposition.Equals (other.xAdsMetaContentDisposition)
				)
				&&
				(
					this.xAdsMetaContentEncoding == other.xAdsMetaContentEncoding ||
					this.xAdsMetaContentEncoding != null &&
					this.xAdsMetaContentEncoding.Equals (other.xAdsMetaContentEncoding)
				)
				&&
				(
					this.xAdsMetaCacheControl == other.xAdsMetaCacheControl ||
					this.xAdsMetaCacheControl != null &&
					this.xAdsMetaCacheControl.Equals (other.xAdsMetaCacheControl)
				)
			);
		}

		public override int GetHashCode () {
			// credit: http://stackoverflow.com/a/263416/677735
			unchecked // Overflow is fine, just wrap
			{
				int hash = 41;
				// Suitable nullity checks etc, of course :)
				if ( this.objectKey != null )
					hash = hash * 59 + this.objectKey.GetHashCode ();
				if ( this.uploadKey != null )
					hash = hash * 59 + this.uploadKey.GetHashCode ();
				if ( this.size != null )
					hash = hash * 59 + this.size.GetHashCode ();
				if ( this.eTags != null )
					hash = hash * 59 + this.eTags.GetHashCode ();
				if ( this.xAdsMetaContentType != null )
					hash = hash * 59 + this.xAdsMetaContentType.GetHashCode ();
				if ( this.xAdsMetaContentDisposition != null )
					hash = hash * 59 + this.xAdsMetaContentDisposition.GetHashCode ();
				if ( this.xAdsMetaContentEncoding != null )
					hash = hash * 59 + this.xAdsMetaContentEncoding.GetHashCode ();
				if ( this.xAdsMetaCacheControl != null )
					hash = hash * 59 + this.xAdsMetaCacheControl.GetHashCode ();
				return (hash);
			}
		}

	}

	/// <summary>
	/// Post PostCompleteS3UploadsPayload Payload Body Structure
	/// </summary>
	[DataContract]
	public partial class PostBatchCompleteS3UploadPayload : IEquatable<PostBatchCompleteS3UploadPayload> {

		[DataMember (Name = "requests", EmitDefaultValue = false)]
		public List<PostBatchCompleteS3UploadPayloadItem> requests { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PostBatchCompleteS3UploadPayload" /> class.
		/// </summary>
		[JsonConstructorAttribute]
		protected PostBatchCompleteS3UploadPayload () { }

		public PostBatchCompleteS3UploadPayload (PostBatchCompleteS3UploadPayloadItem item) {
			this.requests = new List<PostBatchCompleteS3UploadPayloadItem> () { item };
		}

		public PostBatchCompleteS3UploadPayload (List<PostBatchCompleteS3UploadPayloadItem> items) {
			if ( items == null )
				//throw new InvalidDataException ("requests is a required property for PostCompleteS3UploadsPayload and cannot be null or empty");
				items = new List<PostBatchCompleteS3UploadPayloadItem> ();
			this.requests = items;
		}

		public override string ToString () {
			var sb = new StringBuilder ();
			sb.Append ("class PostCompleteS3UploadsPayload {\n");
			sb.Append ("  uploadKey: ").Append (requests).Append ("\n");
			sb.Append ("}\n");
			return (sb.ToString ());
		}

		public string ToJson () {
			return (JsonConvert.SerializeObject (this, Formatting.Indented));
		}

		public override bool Equals (object obj) {
			// credit: http://stackoverflow.com/a/10454552/677735
			return (this.Equals (obj as PostBatchCompleteS3UploadPayload));
		}

		/// <summary>
		/// Returns true if PostCompleteS3UploadsPayload instances are equal
		/// </summary>
		/// <param name="other">Instance of PostCompleteS3UploadsPayload to be compared</param>
		/// <returns>Boolean</returns>
		public bool Equals (PostBatchCompleteS3UploadPayload other) {
			// credit: http://stackoverflow.com/a/10454552/677735
			if ( other == null )
				return (false);

			return (
				(
					this.requests == other.requests ||
					this.requests != null &&
					this.requests.SequenceEqual (other.requests)
				)
			);
		}

		public override int GetHashCode () {
			// credit: http://stackoverflow.com/a/263416/677735
			unchecked // Overflow is fine, just wrap
			{
				int hash = 41;
				// Suitable nullity checks etc, of course :)
				if ( this.requests != null )
					hash = hash * 59 + this.requests.GetHashCode ();
				return (hash);
			}
		}

	}

}

