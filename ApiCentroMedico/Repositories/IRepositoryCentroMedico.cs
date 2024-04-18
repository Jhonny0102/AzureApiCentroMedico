using ApiCentroMedico.Models;

namespace ApiCentroMedico.Repositories
{
    public interface IRepositoryCentroMedico
    {
        public Usuario GetLogin(string correo, string contra); //Hecho
        public int GetIdMedico(int especialidad);

        public void CreatePaciente(string nombre, string apellido, string correo, string contra, int telefono, string direccion, int edad, string genero, int medico); //Hecho
        public void CreateMedico(string nombre, string apellido, string correo, string contra, int especialidad);
        public void CreateUsuario(string nombre, string apellido, string correo, string contra, int tipo); //Hecho

        public void DeleteUsuario(int id, int tipo); //Hecho
        public void EditUsuario(int id, string nombre, string apellido, string correo, string contra, int estado, int tipo); //Hecho
        public void EditMedico(int id, string nombre, string apellido, string correo, string contra, int especialidad, int estado, int tipo);
        public void EditPaciente(int id, string nombre, string apellido, string correo, string contra, int telefono, string direccion, int edad, string genero, int Estado, int tipo); //Hecho

        public List<UsuariosTipo> GetTipoUsuarios(); //Hecho
        public List<Usuario> GetUsuariosTipo(int tipo); //Hecho
        public List<Usuario> GetUsuarios(); //Hecho
        public List<Especialidades> GetEspecialidades();
        public List<CitaDetalladaMedicos> FindCitasPaciente(int idpaciente); //Hecho

        public Paciente FindPaciente(int id); //Hecho
        public PacienteDetallado FindPacienteDetallado(int id); //Hecho
        public DatosExtrasPacientes FindDatosExtrasPacientes(int id); //Hecho
        public Medico FindMedico(int id);
        public MedicoDetallado FindMedicoDetallado(int id); //Hecho
        public MedicoDetallado GetMiMedico(int idPaciente); 
        public Usuario FindUsuario(int id); //Hecho
        public UsuarioDetallado FindUsuarioDetallado(int id); //Hecho

        public CitaDetalladoModel GetAllCitas(int posicion);
        public Cita FindCita(int idCita);
        public void DeleteCita(int idCita);
        public void EditCita(int idCita, DateTime fecha, TimeSpan hora, int idSeguimientoCita, int idMedico, string comentario);
        public List<MedicosPacientes> MisPacientes(int idMedico); //Hecho
        public List<PeticionesDetallado> GetPeticionesDetallado();
        public void OkPetcion(int idPeticion, int idUsuario, int idEstadoNuevo);
        public void OkNoPeticion(int idPeticion);
        public List<PeticionesMedicamentoDetallado> GetPeticionesMedicametentosDetallado();

        public void OkPeticionMedicamento(int idPeti, int? idMedicamento, string nombre, string? descripcion, int estado);
        public void OkNoPeticionMedicamento(int idPeti);
        public void CreatePeticionMedicamentoConId(int idMedico, int idMedicamento, int estadoMedicamento); //Hecho
        public void CreatePeticionUsuarios(int idsolicitante, int idmodificado, int nuevoestado); //Hecho
        public void CreatePeticionMedicamentoSinId(int idMedico, string nombreMedicamento, string descripcionMedicamento); //Hecho
        public List<Medicamentos> GetMedicamentos();
        public Medicamentos FindMedicamento(int idMedicamento);
        public List<Estados> GetEstados();
        public string FindNombreEstado(int idEstado);

        public void CreateCitaPaciente(DateTime fecha, TimeSpan hora, int idmedico, int idpaciente); //Hecho
        public int FindCitaDispo(int idmedico, DateTime fecha, TimeSpan hora); //Hecho
        public List<CitaDetalladaMedicos> GetCitasDetalladasMedico(int idmedico); //Hecho
        public List<CitaDetalladaMedicos> FindCitasDetalladasMedicos(int idmedico, DateTime fecha);
        public List<CitaDetalladaMedicos> FindCitasDetalladasPAciente(int idpaciente, DateTime fechadesde, DateTime? fechahasta); //Hecho
        public List<SeguimientoCita> GetAllSeguimientoCita(); //Hecho
        public void UpdateCitaMedica(int idmedico, int idpaciente, int idcita, string comentario, int seguimiento, List<int> medicamentos); //Hecho
        public List<Medicamentos> GetAllMedicamentos(); //Hecho
        public void UpdateCitaDetalladaPaciente(int idcita, DateTime fecha, TimeSpan hora); //Hecho
        public List<MedicamentoYPaciente> GetAllMedicamentosPaciente(int idpaciente); //Hecho
        public MedicamentoYPaciente FindMedicamentoYPaciente(int id); //Hecho
        public void UpdateMedicamentoYPaciente(int id); //Hecho
        public Paciente FindPacienteDistintoDetallado(string nombre, string apellido, string correo); //Hecho
        public MedicosPacientes GetMedicoPaciente(int idpaciente); //Hecho
        public CitaDetalladaMedicos FindCitasDetalladasMedicosSinFiltro(int idcita); //Hecho
    }
}
