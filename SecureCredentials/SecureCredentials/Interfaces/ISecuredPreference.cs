namespace SecureCredentials
{
    public interface ISecuredPreference
    {
        /// <summary>
        /// Store value in App Preference. 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetValue(string key, string value);

        /// <summary>
        /// Get value for given key from store.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetValue(string key);

        /// <summary>
        /// Encrypt given value and then store into App Preference 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetSecuredValue(string key, string value);

        /// <summary>
        /// Get decrypted value for given key from App Preference.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetSecuredValue(string key);
    }
}
