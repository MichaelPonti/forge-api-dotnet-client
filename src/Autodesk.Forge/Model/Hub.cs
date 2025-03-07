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

namespace Autodesk.Forge.Model
{
    /// <summary>
    /// Hub
    /// </summary>
    [DataContract]
    public partial class Hub :  IEquatable<Hub>
    {
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            
            /// <summary>
            /// Enum Hubs for "hubs"
            /// </summary>
            [EnumMember(Value = "hubs")]
            Hubs
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Hub" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Hub() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Hub" /> class.
        /// </summary>
        /// <param name="Jsonapi">Jsonapi.</param>
        /// <param name="Data">Data (required).</param>
        /// <param name="Included">Included.</param>
        /// <param name="Links">Links (required).</param>
        /// <param name="Id">resource id (required).</param>
        /// <param name="Type">Type (required).</param>
        /// <param name="Attributes">Attributes.</param>
        /// <param name="Meta">Meta.</param>
        /// <param name="Relationships">Relationships.</param>
        public Hub(JsonApiVersionJsonapi Jsonapi = null, JsonApiResource Data = null, List<JsonApiResource> Included = null, JsonApiLinks Links = null, string Id = null, TypeEnum? Type = null, HubAttributes Attributes = null, JsonApiMeta Meta = null, HubRelationships Relationships = null)
        {
            // to ensure "Data" is required (not null)
            if (Data == null)
            {
                throw new InvalidDataException("Data is a required property for Hub and cannot be null");
            }
            else
            {
                this.Data = Data;
            }
            // to ensure "Links" is required (not null)
            if (Links == null)
            {
                throw new InvalidDataException("Links is a required property for Hub and cannot be null");
            }
            else
            {
                this.Links = Links;
            }
            // to ensure "Id" is required (not null)
            if (Id == null)
            {
                throw new InvalidDataException("Id is a required property for Hub and cannot be null");
            }
            else
            {
                this.Id = Id;
            }
            // to ensure "Type" is required (not null)
            if (Type == null)
            {
                throw new InvalidDataException("Type is a required property for Hub and cannot be null");
            }
            else
            {
                this.Type = Type;
            }
            this.Jsonapi = Jsonapi;
            this.Included = Included;
            this.Attributes = Attributes;
            this.Meta = Meta;
            this.Relationships = Relationships;
        }
        
        /// <summary>
        /// Gets or Sets Jsonapi
        /// </summary>
        [DataMember(Name="jsonapi", EmitDefaultValue=false)]
        public JsonApiVersionJsonapi Jsonapi { get; set; }
        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name="data", EmitDefaultValue=false)]
        public JsonApiResource Data { get; set; }
        /// <summary>
        /// Gets or Sets Included
        /// </summary>
        [DataMember(Name="included", EmitDefaultValue=false)]
        public List<JsonApiResource> Included { get; set; }
        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue=false)]
        public JsonApiLinks Links { get; set; }
        /// <summary>
        /// resource id
        /// </summary>
        /// <value>resource id</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        /// Gets or Sets Attributes
        /// </summary>
        [DataMember(Name="attributes", EmitDefaultValue=false)]
        public HubAttributes Attributes { get; set; }
        /// <summary>
        /// Gets or Sets Meta
        /// </summary>
        [DataMember(Name="meta", EmitDefaultValue=false)]
        public JsonApiMeta Meta { get; set; }
        /// <summary>
        /// Gets or Sets Relationships
        /// </summary>
        [DataMember(Name="relationships", EmitDefaultValue=false)]
        public HubRelationships Relationships { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Hub {\n");
            sb.Append("  Jsonapi: ").Append(Jsonapi).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Included: ").Append(Included).Append("\n");
            sb.Append("  Links: ").Append(Links).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Attributes: ").Append(Attributes).Append("\n");
            sb.Append("  Meta: ").Append(Meta).Append("\n");
            sb.Append("  Relationships: ").Append(Relationships).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as Hub);
        }

        /// <summary>
        /// Returns true if Hub instances are equal
        /// </summary>
        /// <param name="other">Instance of Hub to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Hub other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Jsonapi == other.Jsonapi ||
                    this.Jsonapi != null &&
                    this.Jsonapi.Equals(other.Jsonapi)
                ) && 
                (
                    this.Data == other.Data ||
                    this.Data != null &&
                    this.Data.Equals(other.Data)
                ) && 
                (
                    this.Included == other.Included ||
                    this.Included != null &&
                    this.Included.SequenceEqual(other.Included)
                ) && 
                (
                    this.Links == other.Links ||
                    this.Links != null &&
                    this.Links.Equals(other.Links)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
                ) && 
                (
                    this.Attributes == other.Attributes ||
                    this.Attributes != null &&
                    this.Attributes.Equals(other.Attributes)
                ) && 
                (
                    this.Meta == other.Meta ||
                    this.Meta != null &&
                    this.Meta.Equals(other.Meta)
                ) && 
                (
                    this.Relationships == other.Relationships ||
                    this.Relationships != null &&
                    this.Relationships.Equals(other.Relationships)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.Jsonapi != null)
                    hash = hash * 59 + this.Jsonapi.GetHashCode();
                if (this.Data != null)
                    hash = hash * 59 + this.Data.GetHashCode();
                if (this.Included != null)
                    hash = hash * 59 + this.Included.GetHashCode();
                if (this.Links != null)
                    hash = hash * 59 + this.Links.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.Type != null)
                    hash = hash * 59 + this.Type.GetHashCode();
                if (this.Attributes != null)
                    hash = hash * 59 + this.Attributes.GetHashCode();
                if (this.Meta != null)
                    hash = hash * 59 + this.Meta.GetHashCode();
                if (this.Relationships != null)
                    hash = hash * 59 + this.Relationships.GetHashCode();
                return hash;
            }
        }
    }

}

