using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Services
{
	public class APIConnection
	{
		static private Encoding UTF8 = Encoding.GetEncoding("utf-8");
		string key;
		string secret;
		string version;
		string practiceid;
		string baseUrl;
		string token;

		public APIConnection() : this("uhuhawh8u54wmvs5rhvwy549", "5uuDvnJ2PPe8wQB", "preview1", "195900") { }
		public APIConnection(string key, string secret, string version, string practiceid)
		{
			this.key = key;
			this.secret = secret;
			this.version = version;
			this.practiceid = practiceid;
			baseUrl = "https://api.athenahealth.com/";

			token = authenticate();
		}

		// basic authentication
		private string authenticate()
		{
			Dictionary<string, string> auth_prefixes = new Dictionary<string, string>()
				{
					{"v1", "/oauth"},
					{"preview1", "/oauthpreview"},
					{"openpreview1", "/oauthopenpreview"},
				};
			string url = PathJoin(baseUrl, auth_prefixes[version], "/token");

			// Create a new request
			WebRequest request = WebRequest.Create(url);
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";

			// Set the Authorization header for basic auth
			string auth = Convert.ToBase64String(UTF8.GetBytes(string.Format("{0}:{1}", key, secret)));
			request.Headers["Authorization"] = string.Format("Basic {0}", auth);

			Dictionary<string, string> parameters = new Dictionary<string, string>()
				{
					{"grant_type", "client_credentials"},
				};

			// Encode and write the parameters to the request
			byte[] content = UTF8.GetBytes(UrlEncode(parameters));
			Stream writer = request.GetRequestStream();
			writer.Write(content, 0, content.Length);
			writer.Close();

			// Get and decode the response
			WebResponse response = request.GetResponse();
			Stream receive = response.GetResponseStream();
			StreamReader reader = new StreamReader(receive, UTF8);
			JToken authorization = JToken.Parse(reader.ReadToEnd());

			// Don't forget to close the response!
			response.Close();

			// Grab the token!
			return token = (string)authorization["access_token"];
		}

		static public string UrlEncode(Dictionary<string, string> parameters)
		{
			// Encode each key and value, join with "=", then join pairs with "&"
			return string.Join("&", parameters.Select(
				kvp => WebUtility.UrlEncode(kvp.Key) + "=" + WebUtility.UrlEncode(kvp.Value)
			).ToList());
		}

		//   Join arguments into a valid URL.
		static public string PathJoin(params string[] args)
		{
			// Trim slashes, filter out empties, join by slashes
			return string.Join("/", args
								.Select(arg => arg.Trim(new char[] { '/' }))
								.Where(arg => !string.IsNullOrEmpty(arg))
			);
		}

		/// <summary>
		///   Make the API call.
		/// </summary>
		/// <remarks>
		///   <para>
		///     This method abstracts away the streams, readers, and writers necessary to format the
		///     HTTP request.  It also adds in the Authorization header and token.
		///   </para>
		/// </remarks>
		/// <param name="request">The request to format and send</param>
		/// <param name="body">The parameters that will be written to the request body</param>
		/// <param name="headers">The headers that will be added to the request</param>
		/// <param name="secondcall">True if this is the retried call</param>
		/// <returns>The JSON-decoded response</returns>
		private JToken AuthorizedCall(WebRequest request, Dictionary<string, string> body, Dictionary<string, string> headers, bool secondcall = false)
		{
			// First add the auth header, then update with the rest of them.
			request.Headers["Authorization"] = string.Format("Bearer {0}", token);

			if (headers != null)
			{
				foreach (KeyValuePair<string, string> kvp in body)
				{
					request.Headers[kvp.Key] = kvp.Value;
				}
			}

			// Write the body parameters, if there are any.
			if (body != null)
			{
				byte[] content = UTF8.GetBytes(UrlEncode(body));
				Stream writer = request.GetRequestStream();
				writer.Write(content, 0, content.Length);
				writer.Close();
			}

			// Try reading the response, assuming it's good.  If not, read the error response.
			StreamReader reader;
			JToken reply;
			try
			{
				WebResponse response = request.GetResponse();
				reader = new StreamReader(response.GetResponseStream(), UTF8);
				reply = JToken.Parse(reader.ReadToEnd());
				response.Close();
				return reply;
			}
			catch (WebException wex)
			{
				reader = new StreamReader(wex.Response.GetResponseStream(), UTF8);
				reply = JToken.Parse(reader.ReadToEnd());

				// If we get a 401 Not Authorized, re-authenticate and try again.
				if (((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.Unauthorized && !secondcall)
				{
					token = authenticate();

					// We can't reopen the stream from the same request twice, so create a new one that's identical and send that.
					WebRequest retry = WebRequest.Create(request.RequestUri);
					retry.ContentType = request.ContentType;
					retry.Method = request.Method;
					return AuthorizedCall(retry, body, headers, true);
				}
				return reply;
			}
		}

		public JToken GET(string path)
		{
			return GET(path, null, null);
		}

		public JToken GET(string path, Dictionary<string, string> parameters)
		{
			return GET(path, parameters, null);
		}

		public JToken GET(string path, Dictionary<string, string> parameters, Dictionary<string, string> headers)
		{
			string url = PathJoin(baseUrl, version, practiceid, path);
			string query = "";
			if (parameters != null)
			{
				query = "?" + UrlEncode(parameters);
			}

			WebRequest request = WebRequest.Create(url + query);
			request.Method = "GET";

			return AuthorizedCall(request, null, headers);
		}


		public JToken POST(string path)
		{
			return POST(path, null, null);
		}

		public JToken POST(string path, Dictionary<string, string> parameters)
		{
			return POST(path, parameters, null);
		}

		public JToken POST(string path, Dictionary<string, string> parameters, Dictionary<string, string> headers)
		{
			string url = PathJoin(baseUrl, version, practiceid, path);
			WebRequest request = WebRequest.Create(url);
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";

			return AuthorizedCall(request, parameters, headers);
		}


		public JToken PUT(string path)
		{
			return PUT(path, null, null);
		}

		public JToken PUT(string path, Dictionary<string, string> parameters)
		{
			return PUT(path, parameters, null);
		}

		public JToken PUT(string path, Dictionary<string, string> parameters, Dictionary<string, string> headers)
		{
			string url = PathJoin(baseUrl, version, practiceid, path);
			WebRequest request = WebRequest.Create(url);
			request.Method = "PUT";
			request.ContentType = "application/x-www-form-urlencoded";

			return AuthorizedCall(request, parameters, headers);
		}


		public JToken DELETE(string path)
		{
			return DELETE(path, null, null);
		}

		public JToken DELETE(string path, Dictionary<string, string> parameters)
		{
			return DELETE(path, parameters, null);
		}

		public JToken DELETE(string path, Dictionary<string, string> parameters, Dictionary<string, string> headers)
		{
			string url = PathJoin(baseUrl, version, practiceid, path);
			string query = "";
			if (parameters != null)
			{
				query = "?" + UrlEncode(parameters);
			}
			WebRequest request = WebRequest.Create(url + query);
			request.Method = "DELETE";

			return AuthorizedCall(request, null, headers);
		}
		/*
		public string GetToken()
		{
			return token;
		}

		public void SetToken(string token)
		{
			this.token = token;
		}
		*/
	}
}
