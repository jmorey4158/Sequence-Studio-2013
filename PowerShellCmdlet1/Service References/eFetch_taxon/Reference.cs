﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SequencePowerShell.eFetch_taxon {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/", ConfigurationName="eFetch_taxon.eUtilsServiceSoap")]
    public interface eUtilsServiceSoap {
        
        // CODEGEN: Generating message contract since the operation run_eFetch is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="efetch", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SequencePowerShell.eFetch_taxon.run_eFetchResponse run_eFetch(SequencePowerShell.eFetch_taxon.run_eFetchRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/efetch_taxonomy")]
    public partial class eFetchRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string idField;
        
        private string webEnvField;
        
        private string query_keyField;
        
        private string toolField;
        
        private string emailField;
        
        private string reportField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("id");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string WebEnv {
            get {
                return this.webEnvField;
            }
            set {
                this.webEnvField = value;
                this.RaisePropertyChanged("WebEnv");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string query_key {
            get {
                return this.query_keyField;
            }
            set {
                this.query_keyField = value;
                this.RaisePropertyChanged("query_key");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string tool {
            get {
                return this.toolField;
            }
            set {
                this.toolField = value;
                this.RaisePropertyChanged("tool");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
                this.RaisePropertyChanged("email");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string report {
            get {
                return this.reportField;
            }
            set {
                this.reportField = value;
                this.RaisePropertyChanged("report");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/efetch_taxonomy")]
    public partial class PropertyType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string propNameField;
        
        private string itemField;
        
        private ItemChoiceType1 itemElementNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string PropName {
            get {
                return this.propNameField;
            }
            set {
                this.propNameField = value;
                this.RaisePropertyChanged("PropName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PropValueBool", typeof(string), Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("PropValueInt", typeof(string), Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("PropValueString", typeof(string), Order=1)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
                this.RaisePropertyChanged("Item");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType1 ItemElementName {
            get {
                return this.itemElementNameField;
            }
            set {
                this.itemElementNameField = value;
                this.RaisePropertyChanged("ItemElementName");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/efetch_taxonomy", IncludeInSchema=false)]
    public enum ItemChoiceType1 {
        
        /// <remarks/>
        PropValueBool,
        
        /// <remarks/>
        PropValueInt,
        
        /// <remarks/>
        PropValueString,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/efetch_taxonomy")]
    public partial class ModifierType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string modIdField;
        
        private string modTypeField;
        
        private string modNameField;
        
        private string modGBhiddenField;
        
        private string itemField;
        
        private ItemChoiceType itemElementNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ModId {
            get {
                return this.modIdField;
            }
            set {
                this.modIdField = value;
                this.RaisePropertyChanged("ModId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ModType {
            get {
                return this.modTypeField;
            }
            set {
                this.modTypeField = value;
                this.RaisePropertyChanged("ModType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ModName {
            get {
                return this.modNameField;
            }
            set {
                this.modNameField = value;
                this.RaisePropertyChanged("ModName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string ModGBhidden {
            get {
                return this.modGBhiddenField;
            }
            set {
                this.modGBhiddenField = value;
                this.RaisePropertyChanged("ModGBhidden");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RModId", typeof(string), Order=4)]
        [System.Xml.Serialization.XmlElementAttribute("RTaxId", typeof(string), Order=4)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
                this.RaisePropertyChanged("Item");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType ItemElementName {
            get {
                return this.itemElementNameField;
            }
            set {
                this.itemElementNameField = value;
                this.RaisePropertyChanged("ItemElementName");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/efetch_taxonomy", IncludeInSchema=false)]
    public enum ItemChoiceType {
        
        /// <remarks/>
        RModId,
        
        /// <remarks/>
        RTaxId,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/efetch_taxonomy")]
    public partial class CitationType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string citIdField;
        
        private string citKeyField;
        
        private string citUrlField;
        
        private string citTextField;
        
        private string citPubmedIdField;
        
        private string citMedlineIdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string CitId {
            get {
                return this.citIdField;
            }
            set {
                this.citIdField = value;
                this.RaisePropertyChanged("CitId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string CitKey {
            get {
                return this.citKeyField;
            }
            set {
                this.citKeyField = value;
                this.RaisePropertyChanged("CitKey");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string CitUrl {
            get {
                return this.citUrlField;
            }
            set {
                this.citUrlField = value;
                this.RaisePropertyChanged("CitUrl");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string CitText {
            get {
                return this.citTextField;
            }
            set {
                this.citTextField = value;
                this.RaisePropertyChanged("CitText");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string CitPubmedId {
            get {
                return this.citPubmedIdField;
            }
            set {
                this.citPubmedIdField = value;
                this.RaisePropertyChanged("CitPubmedId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string CitMedlineId {
            get {
                return this.citMedlineIdField;
            }
            set {
                this.citMedlineIdField = value;
                this.RaisePropertyChanged("CitMedlineId");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/efetch_taxonomy")]
    public partial class MitoGeneticCodeType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string mGCIdField;
        
        private string mGCNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string MGCId {
            get {
                return this.mGCIdField;
            }
            set {
                this.mGCIdField = value;
                this.RaisePropertyChanged("MGCId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string MGCName {
            get {
                return this.mGCNameField;
            }
            set {
                this.mGCNameField = value;
                this.RaisePropertyChanged("MGCName");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/efetch_taxonomy")]
    public partial class GeneticCodeType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string gCIdField;
        
        private string gCNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string GCId {
            get {
                return this.gCIdField;
            }
            set {
                this.gCIdField = value;
                this.RaisePropertyChanged("GCId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string GCName {
            get {
                return this.gCNameField;
            }
            set {
                this.gCNameField = value;
                this.RaisePropertyChanged("GCName");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/efetch_taxonomy")]
    public partial class NameType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string classCDEField;
        
        private string dispNameField;
        
        private string uniqueNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ClassCDE {
            get {
                return this.classCDEField;
            }
            set {
                this.classCDEField = value;
                this.RaisePropertyChanged("ClassCDE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string DispName {
            get {
                return this.dispNameField;
            }
            set {
                this.dispNameField = value;
                this.RaisePropertyChanged("DispName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string UniqueName {
            get {
                return this.uniqueNameField;
            }
            set {
                this.uniqueNameField = value;
                this.RaisePropertyChanged("UniqueName");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/efetch_taxonomy")]
    public partial class OtherNamesType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string genbankCommonNameField;
        
        private string genbankAcronymField;
        
        private string blastNameField;
        
        private object[] itemsField;
        
        private ItemsChoiceType[] itemsElementNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string GenbankCommonName {
            get {
                return this.genbankCommonNameField;
            }
            set {
                this.genbankCommonNameField = value;
                this.RaisePropertyChanged("GenbankCommonName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string GenbankAcronym {
            get {
                return this.genbankAcronymField;
            }
            set {
                this.genbankAcronymField = value;
                this.RaisePropertyChanged("GenbankAcronym");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string BlastName {
            get {
                return this.blastNameField;
            }
            set {
                this.blastNameField = value;
                this.RaisePropertyChanged("BlastName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Acronym", typeof(string), Order=3)]
        [System.Xml.Serialization.XmlElementAttribute("Anamorph", typeof(string), Order=3)]
        [System.Xml.Serialization.XmlElementAttribute("CommonName", typeof(string), Order=3)]
        [System.Xml.Serialization.XmlElementAttribute("EquivalentName", typeof(string), Order=3)]
        [System.Xml.Serialization.XmlElementAttribute("GenbankAnamorph", typeof(string), Order=3)]
        [System.Xml.Serialization.XmlElementAttribute("GenbankSynonym", typeof(string), Order=3)]
        [System.Xml.Serialization.XmlElementAttribute("Includes", typeof(string), Order=3)]
        [System.Xml.Serialization.XmlElementAttribute("Inpart", typeof(string), Order=3)]
        [System.Xml.Serialization.XmlElementAttribute("Misnomer", typeof(string), Order=3)]
        [System.Xml.Serialization.XmlElementAttribute("Misspelling", typeof(string), Order=3)]
        [System.Xml.Serialization.XmlElementAttribute("Name", typeof(NameType), Order=3)]
        [System.Xml.Serialization.XmlElementAttribute("Synonym", typeof(string), Order=3)]
        [System.Xml.Serialization.XmlElementAttribute("Teleomorph", typeof(string), Order=3)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
                this.RaisePropertyChanged("Items");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order=4)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName {
            get {
                return this.itemsElementNameField;
            }
            set {
                this.itemsElementNameField = value;
                this.RaisePropertyChanged("ItemsElementName");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/efetch_taxonomy", IncludeInSchema=false)]
    public enum ItemsChoiceType {
        
        /// <remarks/>
        Acronym,
        
        /// <remarks/>
        Anamorph,
        
        /// <remarks/>
        CommonName,
        
        /// <remarks/>
        EquivalentName,
        
        /// <remarks/>
        GenbankAnamorph,
        
        /// <remarks/>
        GenbankSynonym,
        
        /// <remarks/>
        Includes,
        
        /// <remarks/>
        Inpart,
        
        /// <remarks/>
        Misnomer,
        
        /// <remarks/>
        Misspelling,
        
        /// <remarks/>
        Name,
        
        /// <remarks/>
        Synonym,
        
        /// <remarks/>
        Teleomorph,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/efetch_taxonomy")]
    public partial class TaxonType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string taxIdField;
        
        private string scientificNameField;
        
        private OtherNamesType otherNamesField;
        
        private string parentTaxIdField;
        
        private string rankField;
        
        private string divisionField;
        
        private GeneticCodeType geneticCodeField;
        
        private MitoGeneticCodeType mitoGeneticCodeField;
        
        private string lineageField;
        
        private TaxonType[] lineageExField;
        
        private CitationType[] citationsField;
        
        private ModifierType[] modifiersField;
        
        private PropertyType[] propertiesField;
        
        private string createDateField;
        
        private string updateDateField;
        
        private string pubDateField;
        
        private string[] akaTaxIdsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string TaxId {
            get {
                return this.taxIdField;
            }
            set {
                this.taxIdField = value;
                this.RaisePropertyChanged("TaxId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ScientificName {
            get {
                return this.scientificNameField;
            }
            set {
                this.scientificNameField = value;
                this.RaisePropertyChanged("ScientificName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public OtherNamesType OtherNames {
            get {
                return this.otherNamesField;
            }
            set {
                this.otherNamesField = value;
                this.RaisePropertyChanged("OtherNames");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string ParentTaxId {
            get {
                return this.parentTaxIdField;
            }
            set {
                this.parentTaxIdField = value;
                this.RaisePropertyChanged("ParentTaxId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Rank {
            get {
                return this.rankField;
            }
            set {
                this.rankField = value;
                this.RaisePropertyChanged("Rank");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Division {
            get {
                return this.divisionField;
            }
            set {
                this.divisionField = value;
                this.RaisePropertyChanged("Division");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public GeneticCodeType GeneticCode {
            get {
                return this.geneticCodeField;
            }
            set {
                this.geneticCodeField = value;
                this.RaisePropertyChanged("GeneticCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public MitoGeneticCodeType MitoGeneticCode {
            get {
                return this.mitoGeneticCodeField;
            }
            set {
                this.mitoGeneticCodeField = value;
                this.RaisePropertyChanged("MitoGeneticCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string Lineage {
            get {
                return this.lineageField;
            }
            set {
                this.lineageField = value;
                this.RaisePropertyChanged("Lineage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=9)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Taxon", IsNullable=false)]
        public TaxonType[] LineageEx {
            get {
                return this.lineageExField;
            }
            set {
                this.lineageExField = value;
                this.RaisePropertyChanged("LineageEx");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=10)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Citation", IsNullable=false)]
        public CitationType[] Citations {
            get {
                return this.citationsField;
            }
            set {
                this.citationsField = value;
                this.RaisePropertyChanged("Citations");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=11)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Modifier", IsNullable=false)]
        public ModifierType[] Modifiers {
            get {
                return this.modifiersField;
            }
            set {
                this.modifiersField = value;
                this.RaisePropertyChanged("Modifiers");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=12)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Property", IsNullable=false)]
        public PropertyType[] Properties {
            get {
                return this.propertiesField;
            }
            set {
                this.propertiesField = value;
                this.RaisePropertyChanged("Properties");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string CreateDate {
            get {
                return this.createDateField;
            }
            set {
                this.createDateField = value;
                this.RaisePropertyChanged("CreateDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string UpdateDate {
            get {
                return this.updateDateField;
            }
            set {
                this.updateDateField = value;
                this.RaisePropertyChanged("UpdateDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string PubDate {
            get {
                return this.pubDateField;
            }
            set {
                this.pubDateField = value;
                this.RaisePropertyChanged("PubDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=16)]
        [System.Xml.Serialization.XmlArrayItemAttribute("TaxId", IsNullable=false)]
        public string[] AkaTaxIds {
            get {
                return this.akaTaxIdsField;
            }
            set {
                this.akaTaxIdsField = value;
                this.RaisePropertyChanged("AkaTaxIds");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/efetch_taxonomy")]
    public partial class eFetchResult : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string eRRORField;
        
        private TaxonType[] taxaSetField;
        
        private string[] idListField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ERROR {
            get {
                return this.eRRORField;
            }
            set {
                this.eRRORField = value;
                this.RaisePropertyChanged("ERROR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Taxon", IsNullable=false)]
        public TaxonType[] TaxaSet {
            get {
                return this.taxaSetField;
            }
            set {
                this.taxaSetField = value;
                this.RaisePropertyChanged("TaxaSet");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Id", IsNullable=false)]
        public string[] IdList {
            get {
                return this.idListField;
            }
            set {
                this.idListField = value;
                this.RaisePropertyChanged("IdList");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class run_eFetchRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/efetch_taxonomy", Order=0)]
        public SequencePowerShell.eFetch_taxon.eFetchRequest eFetchRequest;
        
        public run_eFetchRequest() {
        }
        
        public run_eFetchRequest(SequencePowerShell.eFetch_taxon.eFetchRequest eFetchRequest) {
            this.eFetchRequest = eFetchRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class run_eFetchResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.ncbi.nlm.nih.gov/soap/eutils/efetch_taxonomy", Order=0)]
        public SequencePowerShell.eFetch_taxon.eFetchResult eFetchResult;
        
        public run_eFetchResponse() {
        }
        
        public run_eFetchResponse(SequencePowerShell.eFetch_taxon.eFetchResult eFetchResult) {
            this.eFetchResult = eFetchResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface eUtilsServiceSoapChannel : SequencePowerShell.eFetch_taxon.eUtilsServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class eUtilsServiceSoapClient : System.ServiceModel.ClientBase<SequencePowerShell.eFetch_taxon.eUtilsServiceSoap>, SequencePowerShell.eFetch_taxon.eUtilsServiceSoap {
        
        public eUtilsServiceSoapClient() {
        }
        
        public eUtilsServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public eUtilsServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public eUtilsServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public eUtilsServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SequencePowerShell.eFetch_taxon.run_eFetchResponse SequencePowerShell.eFetch_taxon.eUtilsServiceSoap.run_eFetch(SequencePowerShell.eFetch_taxon.run_eFetchRequest request) {
            return base.Channel.run_eFetch(request);
        }
        
        public SequencePowerShell.eFetch_taxon.eFetchResult run_eFetch(SequencePowerShell.eFetch_taxon.eFetchRequest eFetchRequest) {
            SequencePowerShell.eFetch_taxon.run_eFetchRequest inValue = new SequencePowerShell.eFetch_taxon.run_eFetchRequest();
            inValue.eFetchRequest = eFetchRequest;
            SequencePowerShell.eFetch_taxon.run_eFetchResponse retVal = ((SequencePowerShell.eFetch_taxon.eUtilsServiceSoap)(this)).run_eFetch(inValue);
            return retVal.eFetchResult;
        }
    }
}