﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TutoriaAcademicaDTO", Namespace="http://schemas.datacontract.org/2004/07/Dominio")]
    [System.SerializableAttribute()]
    public partial class TutoriaAcademicaDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> CalificacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ComentarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.TimeSpan> DuracionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> IdSesionTutoriaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdTutoriaAcademicaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> IdUsuarioTutoradoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.ReservacionDTO[] ReservacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.SesionDeTutoriaDTO SesionDeTutoriaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UbicacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.UsuarioDTO UsuarioField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Calificacion {
            get {
                return this.CalificacionField;
            }
            set {
                if ((this.CalificacionField.Equals(value) != true)) {
                    this.CalificacionField = value;
                    this.RaisePropertyChanged("Calificacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Comentario {
            get {
                return this.ComentarioField;
            }
            set {
                if ((object.ReferenceEquals(this.ComentarioField, value) != true)) {
                    this.ComentarioField = value;
                    this.RaisePropertyChanged("Comentario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.TimeSpan> Duracion {
            get {
                return this.DuracionField;
            }
            set {
                if ((this.DuracionField.Equals(value) != true)) {
                    this.DuracionField = value;
                    this.RaisePropertyChanged("Duracion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> IdSesionTutoria {
            get {
                return this.IdSesionTutoriaField;
            }
            set {
                if ((this.IdSesionTutoriaField.Equals(value) != true)) {
                    this.IdSesionTutoriaField = value;
                    this.RaisePropertyChanged("IdSesionTutoria");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdTutoriaAcademica {
            get {
                return this.IdTutoriaAcademicaField;
            }
            set {
                if ((this.IdTutoriaAcademicaField.Equals(value) != true)) {
                    this.IdTutoriaAcademicaField = value;
                    this.RaisePropertyChanged("IdTutoriaAcademica");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> IdUsuarioTutorado {
            get {
                return this.IdUsuarioTutoradoField;
            }
            set {
                if ((this.IdUsuarioTutoradoField.Equals(value) != true)) {
                    this.IdUsuarioTutoradoField = value;
                    this.RaisePropertyChanged("IdUsuarioTutorado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.ReservacionDTO[] Reservacion {
            get {
                return this.ReservacionField;
            }
            set {
                if ((object.ReferenceEquals(this.ReservacionField, value) != true)) {
                    this.ReservacionField = value;
                    this.RaisePropertyChanged("Reservacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.SesionDeTutoriaDTO SesionDeTutoria {
            get {
                return this.SesionDeTutoriaField;
            }
            set {
                if ((object.ReferenceEquals(this.SesionDeTutoriaField, value) != true)) {
                    this.SesionDeTutoriaField = value;
                    this.RaisePropertyChanged("SesionDeTutoria");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Ubicacion {
            get {
                return this.UbicacionField;
            }
            set {
                if ((object.ReferenceEquals(this.UbicacionField, value) != true)) {
                    this.UbicacionField = value;
                    this.RaisePropertyChanged("Ubicacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.UsuarioDTO Usuario {
            get {
                return this.UsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioField, value) != true)) {
                    this.UsuarioField = value;
                    this.RaisePropertyChanged("Usuario");
                }
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SesionDeTutoriaDTO", Namespace="http://schemas.datacontract.org/2004/07/Dominio")]
    [System.SerializableAttribute()]
    public partial class SesionDeTutoriaDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaDeSesionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdPeriodoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdSesionDeTutoriaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumeroDeSesionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaDeSesion {
            get {
                return this.FechaDeSesionField;
            }
            set {
                if ((this.FechaDeSesionField.Equals(value) != true)) {
                    this.FechaDeSesionField = value;
                    this.RaisePropertyChanged("FechaDeSesion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdPeriodo {
            get {
                return this.IdPeriodoField;
            }
            set {
                if ((this.IdPeriodoField.Equals(value) != true)) {
                    this.IdPeriodoField = value;
                    this.RaisePropertyChanged("IdPeriodo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdSesionDeTutoria {
            get {
                return this.IdSesionDeTutoriaField;
            }
            set {
                if ((this.IdSesionDeTutoriaField.Equals(value) != true)) {
                    this.IdSesionDeTutoriaField = value;
                    this.RaisePropertyChanged("IdSesionDeTutoria");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NumeroDeSesion {
            get {
                return this.NumeroDeSesionField;
            }
            set {
                if ((this.NumeroDeSesionField.Equals(value) != true)) {
                    this.NumeroDeSesionField = value;
                    this.RaisePropertyChanged("NumeroDeSesion");
                }
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UsuarioDTO", Namespace="http://schemas.datacontract.org/2004/07/Dominio")]
    [System.SerializableAttribute()]
    public partial class UsuarioDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApellidoMaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApellidoPaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContraseniaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CorreoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdUsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreUsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RolField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.TutoradoDTO[] TutoradoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.TutoradoDTO[] Tutorado1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.TutoriaAcademicaDTO[] TutoriaAcademicaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApellidoMaterno {
            get {
                return this.ApellidoMaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApellidoMaternoField, value) != true)) {
                    this.ApellidoMaternoField = value;
                    this.RaisePropertyChanged("ApellidoMaterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApellidoPaterno {
            get {
                return this.ApellidoPaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApellidoPaternoField, value) != true)) {
                    this.ApellidoPaternoField = value;
                    this.RaisePropertyChanged("ApellidoPaterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Contrasenia {
            get {
                return this.ContraseniaField;
            }
            set {
                if ((object.ReferenceEquals(this.ContraseniaField, value) != true)) {
                    this.ContraseniaField = value;
                    this.RaisePropertyChanged("Contrasenia");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Correo {
            get {
                return this.CorreoField;
            }
            set {
                if ((object.ReferenceEquals(this.CorreoField, value) != true)) {
                    this.CorreoField = value;
                    this.RaisePropertyChanged("Correo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdUsuario {
            get {
                return this.IdUsuarioField;
            }
            set {
                if ((this.IdUsuarioField.Equals(value) != true)) {
                    this.IdUsuarioField = value;
                    this.RaisePropertyChanged("IdUsuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NombreUsuario {
            get {
                return this.NombreUsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreUsuarioField, value) != true)) {
                    this.NombreUsuarioField = value;
                    this.RaisePropertyChanged("NombreUsuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Rol {
            get {
                return this.RolField;
            }
            set {
                if ((object.ReferenceEquals(this.RolField, value) != true)) {
                    this.RolField = value;
                    this.RaisePropertyChanged("Rol");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.TutoradoDTO[] Tutorado {
            get {
                return this.TutoradoField;
            }
            set {
                if ((object.ReferenceEquals(this.TutoradoField, value) != true)) {
                    this.TutoradoField = value;
                    this.RaisePropertyChanged("Tutorado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.TutoradoDTO[] Tutorado1 {
            get {
                return this.Tutorado1Field;
            }
            set {
                if ((object.ReferenceEquals(this.Tutorado1Field, value) != true)) {
                    this.Tutorado1Field = value;
                    this.RaisePropertyChanged("Tutorado1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.TutoriaAcademicaDTO[] TutoriaAcademica {
            get {
                return this.TutoriaAcademicaField;
            }
            set {
                if ((object.ReferenceEquals(this.TutoriaAcademicaField, value) != true)) {
                    this.TutoriaAcademicaField = value;
                    this.RaisePropertyChanged("TutoriaAcademica");
                }
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReservacionDTO", Namespace="http://schemas.datacontract.org/2004/07/Dominio")]
    [System.SerializableAttribute()]
    public partial class ReservacionDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AsuntoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<bool> EstadoAsuntoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<bool> EstadoReservacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.TimeSpan> HoraField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdReservacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> IdTutoriaAcademicaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> NumeroDeTurnoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.TutoradoDTO TutoradoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.TutoriaAcademicaDTO TutoriaAcademicaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Asunto {
            get {
                return this.AsuntoField;
            }
            set {
                if ((object.ReferenceEquals(this.AsuntoField, value) != true)) {
                    this.AsuntoField = value;
                    this.RaisePropertyChanged("Asunto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<bool> EstadoAsunto {
            get {
                return this.EstadoAsuntoField;
            }
            set {
                if ((this.EstadoAsuntoField.Equals(value) != true)) {
                    this.EstadoAsuntoField = value;
                    this.RaisePropertyChanged("EstadoAsunto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<bool> EstadoReservacion {
            get {
                return this.EstadoReservacionField;
            }
            set {
                if ((this.EstadoReservacionField.Equals(value) != true)) {
                    this.EstadoReservacionField = value;
                    this.RaisePropertyChanged("EstadoReservacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.TimeSpan> Hora {
            get {
                return this.HoraField;
            }
            set {
                if ((this.HoraField.Equals(value) != true)) {
                    this.HoraField = value;
                    this.RaisePropertyChanged("Hora");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdReservacion {
            get {
                return this.IdReservacionField;
            }
            set {
                if ((this.IdReservacionField.Equals(value) != true)) {
                    this.IdReservacionField = value;
                    this.RaisePropertyChanged("IdReservacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> IdTutoriaAcademica {
            get {
                return this.IdTutoriaAcademicaField;
            }
            set {
                if ((this.IdTutoriaAcademicaField.Equals(value) != true)) {
                    this.IdTutoriaAcademicaField = value;
                    this.RaisePropertyChanged("IdTutoriaAcademica");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> NumeroDeTurno {
            get {
                return this.NumeroDeTurnoField;
            }
            set {
                if ((this.NumeroDeTurnoField.Equals(value) != true)) {
                    this.NumeroDeTurnoField = value;
                    this.RaisePropertyChanged("NumeroDeTurno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.TutoradoDTO Tutorado {
            get {
                return this.TutoradoField;
            }
            set {
                if ((object.ReferenceEquals(this.TutoradoField, value) != true)) {
                    this.TutoradoField = value;
                    this.RaisePropertyChanged("Tutorado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.TutoriaAcademicaDTO TutoriaAcademica {
            get {
                return this.TutoriaAcademicaField;
            }
            set {
                if ((object.ReferenceEquals(this.TutoriaAcademicaField, value) != true)) {
                    this.TutoriaAcademicaField = value;
                    this.RaisePropertyChanged("TutoriaAcademica");
                }
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TutoradoDTO", Namespace="http://schemas.datacontract.org/2004/07/Dominio")]
    [System.SerializableAttribute()]
    public partial class TutoradoDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdTutorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdTutoradoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.UsuarioDTO UsuarioTutorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.UsuarioDTO UsuarioTutoradoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdTutor {
            get {
                return this.IdTutorField;
            }
            set {
                if ((this.IdTutorField.Equals(value) != true)) {
                    this.IdTutorField = value;
                    this.RaisePropertyChanged("IdTutor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdTutorado {
            get {
                return this.IdTutoradoField;
            }
            set {
                if ((this.IdTutoradoField.Equals(value) != true)) {
                    this.IdTutoradoField = value;
                    this.RaisePropertyChanged("IdTutorado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.UsuarioDTO UsuarioTutor {
            get {
                return this.UsuarioTutorField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioTutorField, value) != true)) {
                    this.UsuarioTutorField = value;
                    this.RaisePropertyChanged("UsuarioTutor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.UsuarioDTO UsuarioTutorado {
            get {
                return this.UsuarioTutoradoField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioTutoradoField, value) != true)) {
                    this.UsuarioTutoradoField = value;
                    this.RaisePropertyChanged("UsuarioTutorado");
                }
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioCalificacion.ICalificacionServicio", CallbackContract=typeof(SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.ICalificacionServicioCallback))]
    public interface ICalificacionServicio {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICalificacionServicio/CalificarTutoria")]
        void CalificarTutoria(string comentario, int calificacion, int idUsuario);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICalificacionServicio/CalificarTutoria")]
        System.Threading.Tasks.Task CalificarTutoriaAsync(string comentario, int calificacion, int idUsuario);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICalificacionServicio/ObtenerCalificaciones")]
        void ObtenerCalificaciones(string nombreUsuario);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICalificacionServicio/ObtenerCalificaciones")]
        System.Threading.Tasks.Task ObtenerCalificacionesAsync(string nombreUsuario);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalificacionServicioCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICalificacionServicio/NotificarCalificacionRegistrada")]
        void NotificarCalificacionRegistrada(string mensaje);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICalificacionServicio/NotificarCalificaciones")]
        void NotificarCalificaciones(SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.TutoriaAcademicaDTO[] calificaciones);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICalificacionServicio/NotificarError")]
        void NotificarError(string mensaje);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalificacionServicioChannel : SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.ICalificacionServicio, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalificacionServicioClient : System.ServiceModel.DuplexClientBase<SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.ICalificacionServicio>, SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion.ICalificacionServicio {
        
        public CalificacionServicioClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public CalificacionServicioClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public CalificacionServicioClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CalificacionServicioClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CalificacionServicioClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void CalificarTutoria(string comentario, int calificacion, int idUsuario) {
            base.Channel.CalificarTutoria(comentario, calificacion, idUsuario);
        }
        
        public System.Threading.Tasks.Task CalificarTutoriaAsync(string comentario, int calificacion, int idUsuario) {
            return base.Channel.CalificarTutoriaAsync(comentario, calificacion, idUsuario);
        }
        
        public void ObtenerCalificaciones(string nombreUsuario) {
            base.Channel.ObtenerCalificaciones(nombreUsuario);
        }
        
        public System.Threading.Tasks.Task ObtenerCalificacionesAsync(string nombreUsuario) {
            return base.Channel.ObtenerCalificacionesAsync(nombreUsuario);
        }
    }
}
