//
// Copyright 2014-2015 Amazon.com, 
// Inc. or its affiliates. All Rights Reserved.
// 
// Licensed under the AWS Mobile SDK For Unity 
// Sample Application License Agreement (the "License"). 
// You may not use this file except in compliance with the 
// License. A copy of the License is located 
// in the "license" file accompanying this file. This file is 
// distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, express or implied. See the License 
// for the specific language governing permissions and 
// limitations under the License.
//

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Threading;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime.Internal;
using System.Collections.Generic;
using Amazon.Util;
using Amazon.DynamoDBv2.Model;


namespace AWSSDK.Examples
{
    public class TableQueryAndScanExample : DynamoDbBaseExample 
    {
        public Button QuitButton;
        /*public Button findRepliesWithLimit;
        public Button findProductsWithPriceLessThanZero;*/
        public Text resultText;

        private IAmazonDynamoDB _client;
		public static string XaxisValue = "0"; //declaring XaxixValue with a type String. If use AttributeValue it cant implicitly convert
        public static string YaxisValue = "0";
		public static string ZaxisValue = "0";
		
        void Start()
        {
			QuitButton.onClick.AddListener(QuitListener);
            _client = Client;
			
        }
        
		public void QuitListener()
        {
            Application.Quit();
        }
		
		/*Each frame we are checking for gyro values*/
		void Update ()
		{
			FindXaxisValueEachFrame();
			FindYaxisValueEachFrame();
			FindZaxisValueEachFrame();
		}
		
        private void FindXaxisValueEachFrame()
        {
            FindXaxisValueHelper(null);
        }
		
		private void FindYaxisValueEachFrame()
        {
            FindYaxisValueHelper(null);
        }
		
		private void FindZaxisValueEachFrame()
        {
            FindZaxisValueHelper(null);
        }
        
		//*******************FIND X*************************
        private void FindXaxisValueHelper(Dictionary<string,AttributeValue> lastKeyEvaluated)
        {
            var request = new ScanRequest
            {
                TableName = "GyroData",
                Limit = 2,
                ExclusiveStartKey = lastKeyEvaluated,
                ExpressionAttributeValues = new Dictionary<string,AttributeValue> {
                        {":val", new AttributeValue { N = "0" }} //the SessionID # we're looking for.
                },
                FilterExpression = "SessionID = :val", //SessionID should be equal, greater or less than
                
                ProjectionExpression = "SessionId, Xaxis" //THE AXIS WE NEED TO FIND
            };
            
            _client.ScanAsync(request,(result)=>{
                foreach (Dictionary<string, AttributeValue> item
                         in result.Response.Items)
                {
                        resultText.text =("\nScanThreadTableUsePaging - printing.....");
                        AssignXvalue(item);
                }
                lastKeyEvaluated = result.Response.LastEvaluatedKey;
                if(lastKeyEvaluated != null && lastKeyEvaluated.Count != 0)
                {
                    FindXaxisValueHelper(lastKeyEvaluated);
                }
            });
        }
        
		//*******************FIND Y*************************
        private void FindYaxisValueHelper(Dictionary<string,AttributeValue> lastKeyEvaluated)
        {
            var request = new ScanRequest
            {
                TableName = "GyroData",
                Limit = 2,
                ExclusiveStartKey = lastKeyEvaluated,
                ExpressionAttributeValues = new Dictionary<string,AttributeValue> {
                        {":val", new AttributeValue { N = "0" }} //the SessionID # we're looking for.
                },
                FilterExpression = "SessionID = :val", //SessionID should be equal, greater or less than
                
                ProjectionExpression = "SessionId, Yaxis" //THE AXIS WE NEED TO FIND
            };
            
            _client.ScanAsync(request,(result)=>{
                foreach (Dictionary<string, AttributeValue> item
                         in result.Response.Items)
                {
                        resultText.text =("\nScanThreadTableUsePaging - printing.....");
                        AssignYvalue(item);
                }
                lastKeyEvaluated = result.Response.LastEvaluatedKey;
                if(lastKeyEvaluated != null && lastKeyEvaluated.Count != 0)
                {
                    FindYaxisValueHelper(lastKeyEvaluated);
                }
            });
        }
		
		//*******************FIND Z*************************
		private void FindZaxisValueHelper(Dictionary<string,AttributeValue> lastKeyEvaluated)
        {
            var request = new ScanRequest
            {
                TableName = "GyroData",
                Limit = 2,
                ExclusiveStartKey = lastKeyEvaluated,
                ExpressionAttributeValues = new Dictionary<string,AttributeValue> {
                        {":val", new AttributeValue { N = "0" }} //the SessionID # we're looking for.
                },
                FilterExpression = "SessionID = :val", //SessionID should be equal, greater or less than
                
                ProjectionExpression = "SessionId, Zaxis" //THE AXIS WE NEED TO FIND
            };
            
            _client.ScanAsync(request,(result)=>{
                foreach (Dictionary<string, AttributeValue> item
                         in result.Response.Items)
                {
                        resultText.text =("\nScanThreadTableUsePaging - printing.....");
                        AssignZvalue(item);
                }
                lastKeyEvaluated = result.Response.LastEvaluatedKey;
                if(lastKeyEvaluated != null && lastKeyEvaluated.Count != 0)
                {
                    FindZaxisValueHelper(lastKeyEvaluated);
                }
            });
        }
		
		
		/***********X is....*******************/
        private void AssignXvalue(Dictionary<string, AttributeValue> attributeList)
        {
            foreach (var kvp in attributeList)
            {
                string attributeName = kvp.Key;
                AttributeValue value = kvp.Value;
				XaxisValue = value.S;
                Debug.Log ("the value of X axis is: " + XaxisValue); //works! outputs X axis as string on logs
				
                resultText.text += 
                (
                    "\n" + attributeName + " " +
                    (value.S == null ? "" : "S=[" + value.S + "]") +
                    (value.N == null ? "" : "N=[" + value.N + "]") +
                    (value.SS == null ? "" : "SS=[" + string.Join(",", value.SS.ToArray()) + "]") +
                    (value.NS == null ? "" : "NS=[" + string.Join(",", value.NS.ToArray()) + "]")
                );
				
            }
			
            resultText.text += ("\n************************************************");
        }
		
		/***********Y is....*******************/
		private void AssignYvalue(Dictionary<string, AttributeValue> attributeList)
        {
            foreach (var kvp in attributeList)
            {
                string attributeName = kvp.Key;
                AttributeValue value = kvp.Value;
				YaxisValue = value.S;
                Debug.Log ("the value of Y axis is: " + YaxisValue); //works! outputs Y axis as string on logs
				
                resultText.text += 
                (
                    "\n" + attributeName + " " +
                    (value.S == null ? "" : "S=[" + value.S + "]") +
                    (value.N == null ? "" : "N=[" + value.N + "]") +
                    (value.SS == null ? "" : "SS=[" + string.Join(",", value.SS.ToArray()) + "]") +
                    (value.NS == null ? "" : "NS=[" + string.Join(",", value.NS.ToArray()) + "]")
                );
				
            }
			
            resultText.text += ("\n************************************************");
        }
		
		/***********Z is....*******************/
		private void AssignZvalue(Dictionary<string, AttributeValue> attributeList)
        {
            foreach (var kvp in attributeList)
            {
                string attributeName = kvp.Key;
                AttributeValue value = kvp.Value;
				ZaxisValue = value.S;
                Debug.Log ("the value of Z axis is: " + ZaxisValue); //works! outputs Z axis as string on logs
				
                resultText.text += 
                (
                    "\n" + attributeName + " " +
                    (value.S == null ? "" : "S=[" + value.S + "]") +
                    (value.N == null ? "" : "N=[" + value.N + "]") +
                    (value.SS == null ? "" : "SS=[" + string.Join(",", value.SS.ToArray()) + "]") +
                    (value.NS == null ? "" : "NS=[" + string.Join(",", value.NS.ToArray()) + "]")
                );
				
            }
			
            resultText.text += ("\n************************************************");
        }
		
    }
}
