using HostCareInsurance.Configs;
using HostCareInsurance.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MobileApp.Services
{
    public class HttpServices
    {
        //public static string access_account = "";

        //public static string Url = "http://192.168.43.194/HostInsuranceAPI/";
        //public static string Url = $"http://{Config.IPAddress}/HostInsuranceAPI/";
        public static string Url = "http://192.168.100.12/HostInsuranceAPI/";
        //public static string Url = "http://192.168.100.161/HostInsuranceAPI/";
        //public static string a2Url = "http://localhost:31396";

        //public static string platformId = "01";

        public static string Get(string url, string access_token, string baseUrl = "")
        {
            if (baseUrl == "") baseUrl = Url;
            try
            {
                var webAddr = baseUrl + "api/" + url;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + access_token);
                httpWebRequest.Method = "GET";

                httpWebRequest.Proxy = WebRequest.DefaultWebProxy;
                httpWebRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
                httpWebRequest.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

                //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                //{
                //    string json = t1.Text;

                //    streamWriter.Write(json);
                //    streamWriter.Flush();
                //}
                //  System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object sender1, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return (result);
                }
            }
            catch (WebException ex)
            {
                StreamReader sr = new StreamReader(ex.Response.GetResponseStream(), true);
                //MessageBox.Show(sr.ReadToEnd());
                return sr.ReadToEnd();
            }
        }
        public static string Pay(string url, object model, out bool isSuccess)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model, Formatting.Indented);

                var webAddr = Url + url;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
               // httpWebRequest.Headers.Add("Authorization", "Bearer " + Config.Token);
                httpWebRequest.Method = "POST";

                httpWebRequest.Proxy = WebRequest.DefaultWebProxy;
                httpWebRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
                httpWebRequest.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                //  System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object sender1, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    isSuccess = true;

                    return (result);
                }
            }
            catch (WebException ex)
            {
                isSuccess = false;

                return ex.Message;
            }
        }


        public static string Post(string url, string json, string baseUrl = "")
        {
            if (baseUrl == "") baseUrl = Url;
            try
            {
                var webAddr = baseUrl + "api/" + url;//Modified
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
               
                httpWebRequest.Method = "POST";

                httpWebRequest.Proxy = WebRequest.DefaultWebProxy;
                httpWebRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
                httpWebRequest.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                //  System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object sender1, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return (result);
                }
            }
            catch (WebException ex)
            {
                StreamReader sr = new StreamReader(ex.Response.GetResponseStream(), true);
                //MessageBox.Show(sr.ReadToEnd());
                return sr.ReadToEnd();
            }
        }


        public static string Put(string url, string json, string access_token, string baseUrl = "")
        {
            if (baseUrl == "") baseUrl = Url;
            try
            {
                var webAddr = baseUrl + "api/" + url;//Modified
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + access_token);
                httpWebRequest.Method = "PUT";

                httpWebRequest.Proxy = WebRequest.DefaultWebProxy;
                httpWebRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
                httpWebRequest.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                //  System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object sender1, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return (result);
                }
            }
            catch (WebException ex)
            {
                StreamReader sr = new StreamReader(ex.Response.GetResponseStream(), true);
                //MessageBox.Show(sr.ReadToEnd());
                return sr.ReadToEnd();
            }
        }
     

    }
}
