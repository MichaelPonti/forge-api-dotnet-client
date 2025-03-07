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
    /// 
    /// </summary>
    [DataContract]
    public partial class MetadataData :  IEquatable<MetadataData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataData" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MetadataData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataData" /> class.
        /// </summary>
        /// <param name="Type">Type (required) (default to &quot;metadata&quot;).</param>
        /// <param name="Metadata">Metadata.</param>
        /// <param name="Objects">Collection of “objects”.</param>
        /// <param name="Collection">Array of objects with their “properties” as a non-hierarchical list..</param>
        public MetadataData(string Type = null, List<MetadataMetadata> Metadata = null, List<MetadataObject> Objects = null, List<MetadataCollection> Collection = null)
        {
            // to ensure "Type" is required (not null)
            if (Type == null)
            {
                throw new InvalidDataException("Type is a required property for MetadataData and cannot be null");
            }
            else
            {
                this.Type = Type;
            }
            this.Metadata = Metadata;
            this.Objects = Objects;
            this.Collection = Collection;
        }
        
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }
        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        [DataMember(Name="metadata", EmitDefaultValue=false)]
        public List<MetadataMetadata> Metadata { get; set; }
        /// <summary>
        /// Collection of “objects”
        /// </summary>
        /// <value>Collection of “objects”</value>
        [DataMember(Name="objects", EmitDefaultValue=false)]
        public List<MetadataObject> Objects { get; set; }
        /// <summary>
        /// Array of objects with their “properties” as a non-hierarchical list.
        /// </summary>
        /// <value>Array of objects with their “properties” as a non-hierarchical list.</value>
        [DataMember(Name="collection", EmitDefaultValue=false)]
        public List<MetadataCollection> Collection { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MetadataData {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  Objects: ").Append(Objects).Append("\n");
            sb.Append("  Collection: ").Append(Collection).Append("\n");
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
            return this.Equals(obj as MetadataData);
        }

        /// <summary>
        /// Returns true if MetadataData instances are equal
        /// </summary>
        /// <param name="other">Instance of MetadataData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MetadataData other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
                ) && 
                (
                    this.Metadata == other.Metadata ||
                    this.Metadata != null &&
                    this.Metadata.SequenceEqual(other.Metadata)
                ) && 
                (
                    this.Objects == other.Objects ||
                    this.Objects != null &&
                    this.Objects.SequenceEqual(other.Objects)
                ) && 
                (
                    this.Collection == other.Collection ||
                    this.Collection != null &&
                    this.Collection.SequenceEqual(other.Collection)
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
                if (this.Type != null)
                    hash = hash * 59 + this.Type.GetHashCode();
                if (this.Metadata != null)
                    hash = hash * 59 + this.Metadata.GetHashCode();
                if (this.Objects != null)
                    hash = hash * 59 + this.Objects.GetHashCode();
                if (this.Collection != null)
                    hash = hash * 59 + this.Collection.GetHashCode();
                return hash;
            }
        }
    }

}

