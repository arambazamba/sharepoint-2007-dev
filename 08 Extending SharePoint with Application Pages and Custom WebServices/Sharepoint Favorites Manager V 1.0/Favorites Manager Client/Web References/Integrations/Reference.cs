﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.1433.
// 
#pragma warning disable 1591

namespace Integrations.Integrations {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="FavoritesWSSoap", Namespace="http://integrations.at/favorites")]
    public partial class FavoritesWS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetSitesOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetFavoritesListsForWebOperationCompleted;
        
        private System.Threading.SendOrPostCallback UploadFavoritesOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRemoteFavoritesOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public FavoritesWS() {
            this.Url = global::Integrations.Properties.Settings.Default.FavoritesManager_Integrations_FavoritesWS;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetSitesCompletedEventHandler GetSitesCompleted;
        
        /// <remarks/>
        public event GetFavoritesListsForWebCompletedEventHandler GetFavoritesListsForWebCompleted;
        
        /// <remarks/>
        public event UploadFavoritesCompletedEventHandler UploadFavoritesCompleted;
        
        /// <remarks/>
        public event GetRemoteFavoritesCompletedEventHandler GetRemoteFavoritesCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://integrations.at/favorites/GetSites", RequestNamespace="http://integrations.at/favorites", ResponseNamespace="http://integrations.at/favorites", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetSites(string siteCollection) {
            object[] results = this.Invoke("GetSites", new object[] {
                        siteCollection});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetSitesAsync(string siteCollection) {
            this.GetSitesAsync(siteCollection, null);
        }
        
        /// <remarks/>
        public void GetSitesAsync(string siteCollection, object userState) {
            if ((this.GetSitesOperationCompleted == null)) {
                this.GetSitesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSitesOperationCompleted);
            }
            this.InvokeAsync("GetSites", new object[] {
                        siteCollection}, this.GetSitesOperationCompleted, userState);
        }
        
        private void OnGetSitesOperationCompleted(object arg) {
            if ((this.GetSitesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSitesCompleted(this, new GetSitesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://integrations.at/favorites/GetFavoritesListsForWeb", RequestNamespace="http://integrations.at/favorites", ResponseNamespace="http://integrations.at/favorites", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetFavoritesListsForWeb(string SiteCollection, string Web) {
            object[] results = this.Invoke("GetFavoritesListsForWeb", new object[] {
                        SiteCollection,
                        Web});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetFavoritesListsForWebAsync(string SiteCollection, string Web) {
            this.GetFavoritesListsForWebAsync(SiteCollection, Web, null);
        }
        
        /// <remarks/>
        public void GetFavoritesListsForWebAsync(string SiteCollection, string Web, object userState) {
            if ((this.GetFavoritesListsForWebOperationCompleted == null)) {
                this.GetFavoritesListsForWebOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetFavoritesListsForWebOperationCompleted);
            }
            this.InvokeAsync("GetFavoritesListsForWeb", new object[] {
                        SiteCollection,
                        Web}, this.GetFavoritesListsForWebOperationCompleted, userState);
        }
        
        private void OnGetFavoritesListsForWebOperationCompleted(object arg) {
            if ((this.GetFavoritesListsForWebCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetFavoritesListsForWebCompleted(this, new GetFavoritesListsForWebCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://integrations.at/favorites/UploadFavorites", RequestNamespace="http://integrations.at/favorites", ResponseNamespace="http://integrations.at/favorites", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void UploadFavorites(string SiteCollection, string SharepointSite, string List, string Favorites) {
            this.Invoke("UploadFavorites", new object[] {
                        SiteCollection,
                        SharepointSite,
                        List,
                        Favorites});
        }
        
        /// <remarks/>
        public void UploadFavoritesAsync(string SiteCollection, string SharepointSite, string List, string Favorites) {
            this.UploadFavoritesAsync(SiteCollection, SharepointSite, List, Favorites, null);
        }
        
        /// <remarks/>
        public void UploadFavoritesAsync(string SiteCollection, string SharepointSite, string List, string Favorites, object userState) {
            if ((this.UploadFavoritesOperationCompleted == null)) {
                this.UploadFavoritesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUploadFavoritesOperationCompleted);
            }
            this.InvokeAsync("UploadFavorites", new object[] {
                        SiteCollection,
                        SharepointSite,
                        List,
                        Favorites}, this.UploadFavoritesOperationCompleted, userState);
        }
        
        private void OnUploadFavoritesOperationCompleted(object arg) {
            if ((this.UploadFavoritesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UploadFavoritesCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://integrations.at/favorites/GetRemoteFavorites", RequestNamespace="http://integrations.at/favorites", ResponseNamespace="http://integrations.at/favorites", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetRemoteFavorites(string SiteCollection, string SharepointSite, string List) {
            object[] results = this.Invoke("GetRemoteFavorites", new object[] {
                        SiteCollection,
                        SharepointSite,
                        List});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetRemoteFavoritesAsync(string SiteCollection, string SharepointSite, string List) {
            this.GetRemoteFavoritesAsync(SiteCollection, SharepointSite, List, null);
        }
        
        /// <remarks/>
        public void GetRemoteFavoritesAsync(string SiteCollection, string SharepointSite, string List, object userState) {
            if ((this.GetRemoteFavoritesOperationCompleted == null)) {
                this.GetRemoteFavoritesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRemoteFavoritesOperationCompleted);
            }
            this.InvokeAsync("GetRemoteFavorites", new object[] {
                        SiteCollection,
                        SharepointSite,
                        List}, this.GetRemoteFavoritesOperationCompleted, userState);
        }
        
        private void OnGetRemoteFavoritesOperationCompleted(object arg) {
            if ((this.GetRemoteFavoritesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRemoteFavoritesCompleted(this, new GetRemoteFavoritesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void GetSitesCompletedEventHandler(object sender, GetSitesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSitesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSitesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void GetFavoritesListsForWebCompletedEventHandler(object sender, GetFavoritesListsForWebCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetFavoritesListsForWebCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetFavoritesListsForWebCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void UploadFavoritesCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void GetRemoteFavoritesCompletedEventHandler(object sender, GetRemoteFavoritesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRemoteFavoritesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRemoteFavoritesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591