using Foundation;
using SecureCredentials.iOS;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(SecuredPreference))]
namespace SecureCredentials.iOS
{
    public class SecuredPreference : ISecuredPreference
    {
        private void Set(string key, string value)
        {
            var nsPref = NSUserDefaults.StandardUserDefaults;
            nsPref[(Constants.PreferenceName + key)] = NSObject.FromObject(value);
            NSUserDefaults.StandardUserDefaults.Synchronize();
        }

        private string Get(string key, string defValue = null)
        {
            try
            {
                return NSUserDefaults.StandardUserDefaults.StringForKey((Constants.PreferenceName + key));
            }
            catch
            {
                return defValue;
            }
        }

        /// <summary>
        /// Store value in App Preference. 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetValue(string key, string value)
        {
            Set(key, value);
        }

        /// <summary>
        /// Get value for given key from store.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            return Get(key, "");
        }

        /// <summary>
        /// Encrypt given value and then store into App Preference 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetSecuredValue(string key, string value)
        {
            //encrypt value
            var encryptedValue = CryptoEngine.Encrypt(value, Constants.CipherKey);
            Set(key, encryptedValue);
        }

        /// <summary>
        /// Get decrypted value for given key from App Preference.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetSecuredValue(string key)
        {
            var value = Get(key, "");

            //decrypt value
            var decryptedValue = CryptoEngine.Decrypt(value, Constants.CipherKey);

            return decryptedValue;
        }
    }
}