using Microsoft.Data.SqlClient;
using MvcCoreAdoNet.Models;
using System.Data;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryDoctores
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryDoctores()
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023;TrustServerCertificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Doctor> GetDoctores()
        {
            string sql = "SELECT * FROM DOCTOR";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctor.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.Apellido = this.reader["APELLIDO"].ToString();
                doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());
                doctores.Add(doctor);
            }
            this.reader.Close();
            this.cn.Close();
            return doctores;
        }

        public List<Doctor> FindDoctorEspecialidad(string especialidad)
        {
            string sql = "SELECT * FROM DOCTOR WHERE ESPECIALIDAD = @ESPECIALIDAD";
            SqlParameter pamespecialidad = new SqlParameter("@ESPECIALIDAD", especialidad);
            this.com.Parameters.Add(pamespecialidad);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctor.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.Apellido = this.reader["APELLIDO"].ToString();
                doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());
                doctores.Add(doctor);
            }
            this.reader.Close();
            this.cn.Close();
            return doctores;
        }

        public List<string> GetEspecialidades()
        {
            string sql = "SELECT DISTINCT ESPECIALIDAD FROM DOCTOR";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<string> especialidades = new List<string>();
            while (this.reader.Read())
            {
                string especialidad = this.reader["ESPECIALIDAD"].ToString();
                especialidades.Add(especialidad);
            }
            this.reader.Close();
            this.cn.Close();
            return especialidades;
        }

        public List<Doctor> FindDoctorHospital(string hospital)
        {
            string sql = "SELECT D.DOCTOR_NO, D.APELLIDO, D.ESPECIALIDAD, D.SALARIO FROM DOCTOR D " +
                "INNER JOIN HOSPITAL H " +
                "ON D.HOSPITAL_COD = H.HOSPITAL_COD " +
                "WHERE H.NOMBRE = @HOSPITAL";
            SqlParameter pamhospital = new SqlParameter("@HOSPITAL", hospital);
            this.com.Parameters.Add(pamhospital);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.Apellido = this.reader["APELLIDO"].ToString();
                doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());
                doctores.Add(doctor);
            }
            this.reader.Close();
            this.cn.Close();
            return doctores;
        }

        public List<string> GetHospitales()
        {
            string sql = "SELECT DISTINCT NOMBRE FROM HOSPITAL ORDER BY NOMBRE DESC";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<string> hospitales = new List<string>();
            while (this.reader.Read())
            {
                string hospital = this.reader["NOMBRE"].ToString();
                hospitales.Add(hospital);
            }
            this.reader.Close();
            this.cn.Close();
            return hospitales;
        }
    }
}
