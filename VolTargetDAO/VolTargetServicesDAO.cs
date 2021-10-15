using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using VolTargetDAO.DTOs;

namespace VolTargetDAO
{
    public interface IVolTargetServicesDAO
    {
        void InsertVolTarget(VolTargetDTO volTargetDTO);
        void InsertTraedr(string trader);
        List<VolTargetDTO> GetVolTargetDTOs(string volTargetName);
    }
    public class VolTargetServicesDAO : IVolTargetServicesDAO
    {
        private const string connectionString = @"Data Source=DESKTOP-E8RMSR9\SQLEXPRESS;Initial Catalog=Pricing;Integrated Security=True";

        public void InsertVolTarget(VolTargetDTO volTargetDTO)
        {
            using (var connexion = new SqlConnection(connectionString))
            {
                connexion.Open();
                var command = new SqlCommand($"INSERT INTO tbl_vol_target VALUES ('{volTargetDTO.Volatility}', '{volTargetDTO.StartDate}', '{volTargetDTO.Underlying}', '{volTargetDTO.VoltargetTrader}', '{volTargetDTO.VolTargetName}')", connexion);
                command.ExecuteNonQuery();
            }
        }

        public void InsertTraedr(string trader)
        {
            using(var connexion = new SqlConnection(connectionString))
            {
                connexion.Open();
                var command = new SqlCommand($"INSERT INTO tbl_trader VALUES ('{trader}')", connexion);
                command.ExecuteNonQuery();
            }
        }

        public List<VolTargetDTO> GetVolTargetDTOs(string volTargetName)
        {
            using (var connexion = new SqlConnection(connectionString))
            {
                connexion.Open();
                var command = new SqlCommand("Comand String", connexion);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_GET_VolTargets";

                var reader = command.ExecuteReader();
                var result = new List<VolTargetDTO>();

                while (reader.Read())
                {
                    var volTargetDTO = new VolTargetDTO();

                    volTargetDTO.Volatility = Convert.ToDouble(reader[0]);
                    volTargetDTO.StartDate = Convert.ToDateTime(reader[1]);
                    volTargetDTO.Underlying = reader.GetString(2);
                    volTargetDTO.VoltargetTrader = reader.GetString(3);
                    volTargetDTO.VolTargetName = reader.GetString(5);
                    if (volTargetDTO.VolTargetName == volTargetName)
                    {
                        volTargetDTO.VolTargetName = reader.GetString(5);
                        result.Add(volTargetDTO);
                    }
                }
                return result;
            }
        }
    }
}
