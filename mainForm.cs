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
                if(string.IsNullOrEmpty(street) == false)
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
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
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
                if((string.IsNullOrEmpty(lat) == false) && (string.IsNullOrEmpty(lon) == false))
                {
                    StringBuilder queryAddress = new StringBuilder();
                    queryAddress.Append("http://maps.google.com/maps?q=");
                    queryAddress.Append(lat + "," + "+");
                    queryAddress.Append(lon);
                    webView21.CoreWebView2.Navigate(queryAddress.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
    }
}
