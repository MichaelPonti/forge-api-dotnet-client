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
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using Autodesk.Forge.Client;
using Autodesk.Forge;
using Autodesk.Forge.Model;

namespace Autodesk.Forge.Test
{
    /// <summary>
    ///  Class for testing ProjectsApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class ProjectsApiTests
    {
        private ProjectsApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new ProjectsApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of ProjectsApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' ProjectsApi
            //Assert.IsInstanceOfType(typeof(ProjectsApi), instance, "instance is a ProjectsApi");
        }

        
        /// <summary>
        /// Test GetHubProjects
        /// </summary>
        [Test]
        public void GetHubProjectsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string hubId = null;
            //List<string> filterId = null;
            //List<string> filterExtensionType = null;
            //var response = instance.GetHubProjects(hubId, filterId, filterExtensionType);
            //Assert.IsInstanceOf<Projects> (response, "response is Projects");
        }
        
        /// <summary>
        /// Test GetProject
        /// </summary>
        [Test]
        public void GetProjectTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string hubId = null;
            //string projectId = null;
            //var response = instance.GetProject(hubId, projectId);
            //Assert.IsInstanceOf<Project> (response, "response is Project");
        }
        
        /// <summary>
        /// Test GetProjectHub
        /// </summary>
        [Test]
        public void GetProjectHubTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string hubId = null;
            //string projectId = null;
            //var response = instance.GetProjectHub(hubId, projectId);
            //Assert.IsInstanceOf<Hub> (response, "response is Hub");
        }
        
        /// <summary>
        /// Test GetProjectTopFolders
        /// </summary>
        [Test]
        public void GetProjectTopFoldersTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string hubId = null;
            //string projectId = null;
            //var response = instance.GetProjectTopFolders(hubId, projectId);
            //Assert.IsInstanceOf<TopFolders> (response, "response is TopFolders");
        }
        
        /// <summary>
        /// Test PostStorage
        /// </summary>
        [Test]
        public void PostStorageTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string projectId = null;
            //CreateStorage body = null;
            //var response = instance.PostStorage(projectId, body);
            //Assert.IsInstanceOf<StorageCreated> (response, "response is StorageCreated");
        }
        
    }

}
