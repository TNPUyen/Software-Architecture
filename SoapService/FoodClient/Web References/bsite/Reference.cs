//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace FoodClient.bsite {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="FoodServiceSoap", Namespace="http://projectasp.org/")]
    public partial class FoodService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetAllOperationCompleted;
        
        private System.Threading.SendOrPostCallback SearchOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetFoodDetailsOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddNewFoodOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteFoodOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateFoodOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public FoodService() {
            this.Url = global::FoodClient.Properties.Settings.Default.FoodClient_bsite_FoodService;
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
        public event GetAllCompletedEventHandler GetAllCompleted;
        
        /// <remarks/>
        public event SearchCompletedEventHandler SearchCompleted;
        
        /// <remarks/>
        public event GetFoodDetailsCompletedEventHandler GetFoodDetailsCompleted;
        
        /// <remarks/>
        public event AddNewFoodCompletedEventHandler AddNewFoodCompleted;
        
        /// <remarks/>
        public event DeleteFoodCompletedEventHandler DeleteFoodCompleted;
        
        /// <remarks/>
        public event UpdateFoodCompletedEventHandler UpdateFoodCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://projectasp.org/GetAll", RequestNamespace="http://projectasp.org/", ResponseNamespace="http://projectasp.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Food[] GetAll() {
            object[] results = this.Invoke("GetAll", new object[0]);
            return ((Food[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllAsync() {
            this.GetAllAsync(null);
        }
        
        /// <remarks/>
        public void GetAllAsync(object userState) {
            if ((this.GetAllOperationCompleted == null)) {
                this.GetAllOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllOperationCompleted);
            }
            this.InvokeAsync("GetAll", new object[0], this.GetAllOperationCompleted, userState);
        }
        
        private void OnGetAllOperationCompleted(object arg) {
            if ((this.GetAllCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllCompleted(this, new GetAllCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://projectasp.org/Search", RequestNamespace="http://projectasp.org/", ResponseNamespace="http://projectasp.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Food[] Search(string keyword) {
            object[] results = this.Invoke("Search", new object[] {
                        keyword});
            return ((Food[])(results[0]));
        }
        
        /// <remarks/>
        public void SearchAsync(string keyword) {
            this.SearchAsync(keyword, null);
        }
        
        /// <remarks/>
        public void SearchAsync(string keyword, object userState) {
            if ((this.SearchOperationCompleted == null)) {
                this.SearchOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSearchOperationCompleted);
            }
            this.InvokeAsync("Search", new object[] {
                        keyword}, this.SearchOperationCompleted, userState);
        }
        
        private void OnSearchOperationCompleted(object arg) {
            if ((this.SearchCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SearchCompleted(this, new SearchCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://projectasp.org/GetFoodDetails", RequestNamespace="http://projectasp.org/", ResponseNamespace="http://projectasp.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Food GetFoodDetails(int Id) {
            object[] results = this.Invoke("GetFoodDetails", new object[] {
                        Id});
            return ((Food)(results[0]));
        }
        
        /// <remarks/>
        public void GetFoodDetailsAsync(int Id) {
            this.GetFoodDetailsAsync(Id, null);
        }
        
        /// <remarks/>
        public void GetFoodDetailsAsync(int Id, object userState) {
            if ((this.GetFoodDetailsOperationCompleted == null)) {
                this.GetFoodDetailsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetFoodDetailsOperationCompleted);
            }
            this.InvokeAsync("GetFoodDetails", new object[] {
                        Id}, this.GetFoodDetailsOperationCompleted, userState);
        }
        
        private void OnGetFoodDetailsOperationCompleted(object arg) {
            if ((this.GetFoodDetailsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetFoodDetailsCompleted(this, new GetFoodDetailsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://projectasp.org/AddNewFood", RequestNamespace="http://projectasp.org/", ResponseNamespace="http://projectasp.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool AddNewFood(Food newfood) {
            object[] results = this.Invoke("AddNewFood", new object[] {
                        newfood});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void AddNewFoodAsync(Food newfood) {
            this.AddNewFoodAsync(newfood, null);
        }
        
        /// <remarks/>
        public void AddNewFoodAsync(Food newfood, object userState) {
            if ((this.AddNewFoodOperationCompleted == null)) {
                this.AddNewFoodOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddNewFoodOperationCompleted);
            }
            this.InvokeAsync("AddNewFood", new object[] {
                        newfood}, this.AddNewFoodOperationCompleted, userState);
        }
        
        private void OnAddNewFoodOperationCompleted(object arg) {
            if ((this.AddNewFoodCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddNewFoodCompleted(this, new AddNewFoodCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://projectasp.org/DeleteFood", RequestNamespace="http://projectasp.org/", ResponseNamespace="http://projectasp.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool DeleteFood(int Id) {
            object[] results = this.Invoke("DeleteFood", new object[] {
                        Id});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void DeleteFoodAsync(int Id) {
            this.DeleteFoodAsync(Id, null);
        }
        
        /// <remarks/>
        public void DeleteFoodAsync(int Id, object userState) {
            if ((this.DeleteFoodOperationCompleted == null)) {
                this.DeleteFoodOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteFoodOperationCompleted);
            }
            this.InvokeAsync("DeleteFood", new object[] {
                        Id}, this.DeleteFoodOperationCompleted, userState);
        }
        
        private void OnDeleteFoodOperationCompleted(object arg) {
            if ((this.DeleteFoodCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteFoodCompleted(this, new DeleteFoodCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://projectasp.org/UpdateFood", RequestNamespace="http://projectasp.org/", ResponseNamespace="http://projectasp.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool UpdateFood(Food food) {
            object[] results = this.Invoke("UpdateFood", new object[] {
                        food});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateFoodAsync(Food food) {
            this.UpdateFoodAsync(food, null);
        }
        
        /// <remarks/>
        public void UpdateFoodAsync(Food food, object userState) {
            if ((this.UpdateFoodOperationCompleted == null)) {
                this.UpdateFoodOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateFoodOperationCompleted);
            }
            this.InvokeAsync("UpdateFood", new object[] {
                        food}, this.UpdateFoodOperationCompleted, userState);
        }
        
        private void OnUpdateFoodOperationCompleted(object arg) {
            if ((this.UpdateFoodCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateFoodCompleted(this, new UpdateFoodCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://projectasp.org/")]
    public partial class Food {
        
        private int idField;
        
        private string nameField;
        
        private string typeField;
        
        private string descriptionField;
        
        private System.Nullable<int> priceField;
        
        private System.Nullable<int> amountField;
        
        private string statusField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Price {
            get {
                return this.priceField;
            }
            set {
                this.priceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Amount {
            get {
                return this.amountField;
            }
            set {
                this.amountField = value;
            }
        }
        
        /// <remarks/>
        public string Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetAllCompletedEventHandler(object sender, GetAllCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Food[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Food[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void SearchCompletedEventHandler(object sender, SearchCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SearchCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SearchCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Food[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Food[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetFoodDetailsCompletedEventHandler(object sender, GetFoodDetailsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetFoodDetailsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetFoodDetailsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Food Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Food)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void AddNewFoodCompletedEventHandler(object sender, AddNewFoodCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddNewFoodCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddNewFoodCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void DeleteFoodCompletedEventHandler(object sender, DeleteFoodCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeleteFoodCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DeleteFoodCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void UpdateFoodCompletedEventHandler(object sender, UpdateFoodCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateFoodCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateFoodCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591