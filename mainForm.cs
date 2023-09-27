using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.AxHost;

namespace ReverseGeoCode
{
    public partial class mainForm : Form
    {
        public string urlGetAddress = @"https://nominatim.openstreetmap.org/reverse?format=json&lat={0}&lon={1}";
        public string urlGetLatLon = @"https://nominatim.openstreetmap.org/search?format=json&lat={0}&lon={1}";
        //https://nominatim.openstreetmap.org/search?amenity=gharonda&street=gulmohar%20path&city=pune&state=%20Maharashtra&postalcode=411004&format=json
        //to search by parameter
        //amenity	name and/or type of POI
        //street housenumber and streetname
        //city city
        //county county
        //state state
        //country country
        //postalcode postal code

        public mainForm()
        {
            InitializeComponent();
            //EnsureBrowserEmulationEnabled();
        }

        private void btnGetAddress_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            webClient.Headers.Add("Referer", "http://www.microsoft.com");
            var jsonData = webClient.DownloadString(string.Format(urlGetAddress, txtLat.Text, txtLon.Text));
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(RootObject));
            jsonRoot rootObject = JsonConvert.DeserializeObject<jsonRoot>(jsonData);
            txtFullJson.Text = jsonData;
            txtParsedAddress.Text = "";
            txtParsedAddress.Text += "place_id: " + rootObject.place_id + Environment.NewLine;
            txtParsedAddress.Text += "licence: " + rootObject.licence + Environment.NewLine;
            txtParsedAddress.Text += "osm_type: " + rootObject.osm_type + Environment.NewLine;
            txtParsedAddress.Text += "osm_id: " + rootObject.osm_id + Environment.NewLine;
            txtParsedAddress.Text += "lat: " + rootObject.lat + Environment.NewLine;
            txtParsedAddress.Text += "lon: " + rootObject.lon + Environment.NewLine;
            txtParsedAddress.Text += "class: " + rootObject.@class + Environment.NewLine;
            txtParsedAddress.Text += "type: " + rootObject.type + Environment.NewLine;
            txtParsedAddress.Text += "place_rank: " + rootObject.place_rank + Environment.NewLine;
            txtParsedAddress.Text += "importance: " + rootObject.importance + Environment.NewLine;
            txtParsedAddress.Text += "addresstype: " + rootObject.addresstype + Environment.NewLine;
            txtParsedAddress.Text += "name: " + rootObject.name + Environment.NewLine;
            txtParsedAddress.Text += "display_name: " + rootObject.display_name + Environment.NewLine;
            txtParsedAddress.Text += "address: " + Environment.NewLine;
            txtParsedAddress.Text += "\t" + "neighbourhood: " + rootObject.address.neighbourhood + Environment.NewLine;
            txtParsedAddress.Text += "\t" + "suburb: " + rootObject.address.suburb + Environment.NewLine;
            txtParsedAddress.Text += "\t" + "city: " + rootObject.address.city + Environment.NewLine;
            txtParsedAddress.Text += "\t" + "state_district: " + rootObject.address.state_district + Environment.NewLine;
            txtParsedAddress.Text += "\t" + "state: " + rootObject.address.state + Environment.NewLine;
            txtParsedAddress.Text += "\t" + "ISO3166-2-lvl4: " + rootObject.address.ISO31662lvl4 + Environment.NewLine;
            txtParsedAddress.Text += "\t" + "postcode: " + rootObject.address.postcode + Environment.NewLine;
            txtParsedAddress.Text += "\t" + "country: " + rootObject.address.country + Environment.NewLine;
            txtParsedAddress.Text += "\t" + "country_code: " + rootObject.address.country_code + Environment.NewLine;
            txtParsedAddress.Text += "Bounding Box:" + Environment.NewLine;
            foreach (var boundingentry in rootObject.boundingbox)
            {
                txtParsedAddress.Text += "\t" + boundingentry.ToString() + Environment.NewLine;
            }
        }

        private void btnSearchMapAddress_Click(object sender, EventArgs e)
        {
            string street = txtStreet.Text;
            string city = txtCity.Text;
            string state = txtState.Text;
            string postalCode = txtPostalCode.Text;
            try
            {
                StringBuilder queryAddress = new StringBuilder();
                queryAddress.Append("http://maps.google.com/maps?q=");
                if (string.IsNullOrEmpty(street) == false)
                {
                    queryAddress.Append(street + "," + "+");
                }
                if (string.IsNullOrEmpty(city) == false)
                {
                    queryAddress.Append(city + "," + "+");
                }
                if (string.IsNullOrEmpty(state) == false)
                {
                    queryAddress.Append(state + "," + "+");
                }
                if (string.IsNullOrEmpty(postalCode) == false)
                {
                    queryAddress.Append(postalCode);// + "," + "+");
                }
                webView21.CoreWebView2.Navigate(queryAddress.ToString());

                WebClient webClient = new WebClient();
                webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                webClient.Headers.Add("Referer", "http://www.microsoft.com");
                var jsonData = webClient.DownloadString(queryAddress.ToString());
                int startScriptIndex = jsonData.IndexOf("<script nonce=", 0) + "<script nonce=".Length;
                int endScriptIndex = jsonData.IndexOf("</script>", startScriptIndex);
                string scriptNodeText = jsonData.Substring(startScriptIndex, endScriptIndex - startScriptIndex);
                //XmlDocument xmlDocument = new XmlDocument();
                //xmlDocument.LoadXml(jsonData);
                //XmlNodeList scriptNodeList = xmlDocument.GetElementsByTagName("script");
                //XmlNode firstScriptNode = scriptNodeList[0];
                //string scriptNodeText = firstScriptNode.InnerText;
                string[] scriptNodeTextArray = scriptNodeText.Split(new char[] { '[', '[' });
                string foundLatLongLine = string.Empty;
                string[] foundLatLongLineArray;
                tbFoundLat.Text = string.Empty;
                tbFoundLong.Text = string.Empty;

                if (scriptNodeTextArray.Length >= 205)
                {
                    if(FindLatLongFromOutput(scriptNodeTextArray, 205, 2, 3) == false)
                    {
                        if (scriptNodeTextArray.Length >= 208)
                        {
                            if (FindLatLongFromOutput(scriptNodeTextArray, 208, 2, 3) == false)
                            {
                                tbFoundLat.Text = "Not Found";
                                tbFoundLong.Text = "Not Found";
                            }

                        }
                    }
                }
                //StringBuilder sb = new StringBuilder();
                //for (int i = 0; i < scriptNodeTextArray.Length; i++)
                //{
                //    sb.AppendLine("counter= " + i.ToString() + "value= " + scriptNodeTextArray[i]);
                //}
                //if (sb.Length > 0)
                //{
                //    File.WriteAllText(AppContext.BaseDirectory + "log.txt", sb.ToString());
                //}
                //Source address
                //counter= 105value= \"Gharonda Gulmohar Path, Pune, Maharashtra, 411004\",null,null,
                //lat long for address searched
                //DO not use counter = 81, 107,223,238,258,273,286,301,330,341,356,267,412,416,420,424,428,432,436
                //  440,447,475,490,512, 516
                //USE counter = 205 to get lat lon
                //counter= 205value= null,null,18.510616499999998,73.8289028],\"0x3bc2bf91f3a4d345:0x3a15faa4bacb5af3\",\"Gharonda Apartment\",null,
                //OR Use counter = 249 to get lat lon
                //counter= 249value= 1,0]],1,null,0,0]],null,\"Gulmohar Path, Erandwana, Gokhalenagar, Pune, Maharashtra 411004\",null,null,\"https://www.google.com/maps/preview/place/Gharonda+Apartment,+Gulmohar+Path,+Erandwana,+Gokhalenagar,+Pune,+Maharashtra+411004/@18.5106165,73.8289028,3783a,13.1y/data\\u003d!4m2!3m1!1s0x3bc2bf91f3a4d345:0x3a15faa4bacb5af3\",1,null,null,null,null,null,null,null,null,
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        public bool FindLatLongFromOutput(string[] sourceArray, int targetindex, int latIndex, int longIndex)
        {
            bool bfound = false;
            string foundLatLongLine = sourceArray[targetindex];
            string[] foundLatLongLineArray = foundLatLongLine.Split(new char[] { ',' });

            for (int i = 0; i < foundLatLongLineArray.Length; i++)
            {
                if ((foundLatLongLineArray[i].Contains("null") == true) || (string.IsNullOrEmpty(foundLatLongLineArray[i])))
                {
                    continue;
                }
                else
                {
                    bfound = true;
                    break;
                }
            }
            if (bfound == true)
            {
                tbFoundLat.Text = foundLatLongLineArray[latIndex].Trim(new char[] { ']' });
                tbFoundLong.Text = foundLatLongLineArray[longIndex].Trim(new char[] { ']' });
            }
            return bfound;
        }
        public static void EnsureBrowserEmulationEnabled(string exename = "ReverseGeoCode.exe", bool uninstall = false)
        {

            try
            {
                using (
                    var rk = Registry.CurrentUser.OpenSubKey(
                            @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true)
                )
                {
                    if (!uninstall)
                    {
                        dynamic value = rk.GetValue(exename);
                        if (value == null)
                            rk.SetValue(exename, (uint)11001, RegistryValueKind.DWord);
                    }
                    else
                        rk.DeleteValue(exename);
                }
            }
            catch
            {
            }
        }

        private void btnSearchMapLatLong_Click(object sender, EventArgs e)
        {
            string lat = txtLatMap.Text;
            string lon = txtLonMap.Text;
            try
            {
                if ((string.IsNullOrEmpty(lat) == false) && (string.IsNullOrEmpty(lon) == false))
                {
                    StringBuilder queryAddress = new StringBuilder();
                    queryAddress.Append("http://maps.google.com/maps?q=");
                    queryAddress.Append(lat + "," + "+");
                    queryAddress.Append(lon);
                    webView21.CoreWebView2.Navigate(queryAddress.ToString());

                    WebClient webClient = new WebClient();
                    webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    webClient.Headers.Add("Referer", "http://www.microsoft.com");
                    var jsonData = webClient.DownloadString(queryAddress.ToString());
                    int startScriptIndex = jsonData.IndexOf("<script nonce=", 0) + "<script nonce=".Length;
                    int endScriptIndex = jsonData.IndexOf("</script>", startScriptIndex);
                    string scriptNodeText = jsonData.Substring(startScriptIndex, endScriptIndex - startScriptIndex);
                    //XmlDocument xmlDocument = new XmlDocument();
                    //xmlDocument.LoadXml(jsonData);
                    //XmlNodeList scriptNodeList = xmlDocument.GetElementsByTagName("script");
                    //XmlNode firstScriptNode = scriptNodeList[0];
                    //string scriptNodeText = firstScriptNode.InnerText;
                    string[] scriptNodeTextArray = scriptNodeText.Split(new char[] { '[', '[' });
                    string targetDetailLine = string.Empty;
                    string foundMatchingAddress;
                    if (scriptNodeTextArray.Length >= 225)
                    {
                        targetDetailLine = scriptNodeTextArray[225];

                        int startAddIndex = -1;
                        int endAddIndex = -1;

                        tbFoundAddress.Text = "Not Found!";
                        startAddIndex = targetDetailLine.IndexOf("\"", 0) + "\"".Length;
                        if (startAddIndex >= 0)
                        {
                            endAddIndex = targetDetailLine.IndexOf("\\\"", startAddIndex);
                            if (endAddIndex >= 0)
                            {
                                foundMatchingAddress = targetDetailLine.Substring(startAddIndex, endAddIndex - startAddIndex);
                                tbFoundAddress.Text = foundMatchingAddress;
                            }
                        }

                    }
                    //StringBuilder sb = new StringBuilder();
                    //for (int i = 0; i < scriptNodeTextArray.Length; i++)
                    //{
                    //    sb.AppendLine("counter= " + i.ToString() + "value= " + scriptNodeTextArray[i]);
                    //}
                    //if (sb.Length > 0)
                    //{
                    //    File.WriteAllText(AppContext.BaseDirectory + "log.txt", sb.ToString());
                    //}
                    //Source lat lon
                    //counter= 105value= \"18.51081, 73.82893\",null,null,

                    //DO not use counter = 81, 107,223,238,258,273,286,301,330,341,356,267,412,416,420,424,428,432,436
                    //  440,447,475,490,512, 516
                    //USE counter = 205 to get
                    //counter= 205value= null,null,18.510616499999998,73.8289028],\"0x3bc2bf91f3a4d345:0x3a15faa4bacb5af3\",\"Gharonda Apartment\",null,
                    //Use counter = 245
                    //counter= 249value= 1,0]],1,null,0,0]],null,\"Gulmohar Path, Erandwana, Gokhalenagar, Pune, Maharashtra 411004\",null,null,\"https://www.google.com/maps/preview/place/Gharonda+Apartment,+Gulmohar+Path,+Erandwana,+Gokhalenagar,+Pune,+Maharashtra+411004/@18.5106165,73.8289028,3783a,13.1y/data\\u003d!4m2!3m1!1s0x3bc2bf91f3a4d345:0x3a15faa4bacb5af3\",1,null,null,null,null,null,null,null,null,

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
    }
}
