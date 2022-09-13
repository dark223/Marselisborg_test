﻿using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarselisborgAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefugeeAPIController : ControllerBase
    {
        private IConfiguration _configuration;
        public RefugeeAPIController(IConfiguration Configuration)
        {

            _configuration = Configuration;
        }
       

        


        [HttpGet("AllRefugees")]
        public IEnumerable<Refugee> AllRefugees()
        {
            List<Refugee> Refugees = new List<Refugee>();
            try
            {
                string QueryString = "SELECT * FROM public.flygtning";
              
               

                using (NpgsqlConnection Connection = new NpgsqlConnection(_configuration.GetConnectionString("db")))
                {
                    NpgsqlCommand Cmd = new NpgsqlCommand(QueryString, Connection);
                 
                    Cmd.Connection.Open();
                    var Reader = Cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (Reader.Read())
                    {

                        int? ID = null;
                        string Name = "Not found";
                        int Age = 0;
                        int Center = 0;
                        int? Familiy = null;
                        if (!Reader.IsDBNull(0))
                        {
                            ID = Reader.GetInt32(0);
                        }
                        if (!Reader.IsDBNull(1))
                        {
                            Name = Reader.GetString(1);
                        }
                        if (!Reader.IsDBNull(2))
                        {
                            Age = Reader.GetInt32(2);
                        }
                        if (!Reader.IsDBNull(3))
                        {
                            Center = Reader.GetInt32(3);
                        }
                        if (!Reader.IsDBNull(3))
                        {
                            Familiy = Reader.GetInt32(3);
                        }
                        Refugees.Add(new Refugee(ID, Name, Age, Center, Familiy));
                    }

                    return Refugees;
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }



        [HttpGet("AllRefugeeCenters")]
        public IEnumerable<RefugeeCenter> AllRefugeeCenters()
        {
            List<RefugeeCenter> Centers = new List<RefugeeCenter>();
            


            try
            {
                string QueryString = "SELECT * FROM public.opholdssted";
                using (NpgsqlConnection Connection = new NpgsqlConnection(_configuration.GetConnectionString("db")))
                {
                    NpgsqlCommand Cmd = new NpgsqlCommand(QueryString, Connection);

                    Cmd.Connection.Open();
                    var Reader = Cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (Reader.Read())
                    {

                        Centers.Add(new RefugeeCenter(Reader.GetInt32(0),Reader.GetString(1)));
                    }

                    return Centers;
                }

            }
            catch (Exception e)
            {

                throw e;
            }




        }


        [HttpGet("AllRefugeesFromCenter/{CenterID}")]
        public IEnumerable<Refugee> AllRefugeesFromCenter(int CenterID)
        {
            List<Refugee> Refugees = new List<Refugee>();
            try
            {
                string QueryString = "SELECT * FROM public.flygtning where flygtning.center = @ID";
                using (NpgsqlConnection Connection = new NpgsqlConnection(_configuration.GetConnectionString("db")))
                {
                    NpgsqlCommand Cmd = new NpgsqlCommand(QueryString, Connection);
                    NpgsqlParameter[] Param = new NpgsqlParameter[1];
                    Param[0] = new NpgsqlParameter("@ID", CenterID);

                    Cmd.Parameters.Add(Param[0]);

                    Cmd.Connection.Open();
                    var Reader = Cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (Reader.Read())
                    {

                        int? ID = null;
                        string Name = "Not found";
                        int Age = 0;
                        int Center = 0;
                        int? Familiy = null;
                        if (!Reader.IsDBNull(0))
                        {
                            ID = Reader.GetInt32(0);
                        }
                        if (!Reader.IsDBNull(1))
                        {
                            Name = Reader.GetString(1);
                        }
                        if (!Reader.IsDBNull(2))
                        {
                            Age = Reader.GetInt32(2);
                        }
                        if (!Reader.IsDBNull(3))
                        {
                            Center = Reader.GetInt32(3);
                        } if (!Reader.IsDBNull(4))
                        {
                            Familiy = Reader.GetInt32(4);
                        }

                        Refugees.Add(new Refugee(ID, Name, Age, Center, Familiy));
                    }

                    return Refugees;
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }


        [HttpGet("RefugeeFamilly/{RefugeeID}")]
        public IEnumerable<Refugee> RefugeeFamilly( int RefugeeID)
        {
            List<Refugee> Refugees = new List<Refugee>();
            try
            {
                int? ID = null;
                string QueryString = "SELECT familieID FROM public.flygtning where flygtning.flygtning_id=@ID";
                using (NpgsqlConnection Connection = new NpgsqlConnection(_configuration.GetConnectionString("db")))
                {
                    NpgsqlCommand Cmd = new NpgsqlCommand(QueryString, Connection);
                    NpgsqlParameter[] Param = new NpgsqlParameter[1];
                    Param[0] = new NpgsqlParameter("@ID", RefugeeID);

                    Cmd.Parameters.Add(Param[0]);

                    Cmd.Connection.Open();
                    var Reader = Cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (Reader.Read())
                    {

                        
                        if (!Reader.IsDBNull(0))
                        {
                            ID = Reader.GetInt32(0);
                        }
                    }

                 
                }

                if (ID!=null)
                {

                    string FindFamily = "SELECT * FROM public.flygtning where flygtning.familieID=@ID";
                    using (NpgsqlConnection Connection = new NpgsqlConnection(_configuration.GetConnectionString("db")))
                    {
                        NpgsqlCommand Cmd = new NpgsqlCommand(FindFamily, Connection);
                        NpgsqlParameter[] Param = new NpgsqlParameter[1];
                        Param[0] = new NpgsqlParameter("@ID", ID);
              
                        Cmd.Parameters.Add(Param[0]);

                        Cmd.Connection.Open();
                       var Reader = Cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                        while (Reader.Read())
                        {

                            int? FamiliyID = null;
                            string Name = "Not found";
                            int Age = 0;
                            int Center = 0;
                            int? Familiy = null;
                            if (!Reader.IsDBNull(0))
                            {
                                FamiliyID = Reader.GetInt32(0);
                            }
                            if (!Reader.IsDBNull(1))
                            {
                                Name = Reader.GetString(1);
                            }
                            if (!Reader.IsDBNull(2))
                            {
                                Age = Reader.GetInt32(2);
                            }
                            if (!Reader.IsDBNull(3))
                            {
                                Center = Reader.GetInt32(3);
                            }
                            if (!Reader.IsDBNull(4))
                            {
                                Familiy = Reader.GetInt32(4);
                            }

                            Refugees.Add(new Refugee(FamiliyID, Name, Age, Center, Familiy));
                        }
            
                    }

                }
                        return Refugees;

            }
            catch (Exception e)
            {

                throw e;
            }

        }



        [HttpPost("AddRefugee")]
        public string AddRefugee([FromBody]RefugeeDTO Person)
        {
            try
            {
                string QueryString = "INSERT INTO public.flygtning(navn, alder, center,familieID)	VALUES( @name, @age, @center,@familiy); ";
                using (NpgsqlConnection Connection = new NpgsqlConnection(_configuration.GetConnectionString("db")))
                {
                    NpgsqlCommand Cmd = new NpgsqlCommand(QueryString, Connection);
                    NpgsqlParameter[] Param = new NpgsqlParameter[4];
                    Param[0] = new NpgsqlParameter("@name", Person.Navn);
                    Param[1] = new NpgsqlParameter("@age", Person.Alder);
                    Param[2] = new NpgsqlParameter("@center",Person.FlygtningeCenterID);
                    Param[3] = new NpgsqlParameter("@familiy",Person.FamilieID);
                    Cmd.Parameters.Add(Param[0]);
                    Cmd.Parameters.Add(Param[1]);
                    Cmd.Parameters.Add(Param[2]);
                    Cmd.Parameters.Add(Param[3]);
                    Cmd.Connection.Open();
                    Cmd.ExecuteNonQuery();
            
                }


                return "Refugee added";  

            }
            catch (Exception e)
            {

           

                return "Failed to add Refugee";
            }
        }



        [HttpPost("AddFamily/{FamilyName}")]
        public string AddFamily(string FamilyName)
        {
            try
            {
                string QueryString = "INSERT INTO public.familie(name)	VALUES( @name); ";
                using (NpgsqlConnection Connection = new NpgsqlConnection(_configuration.GetConnectionString("db")))
                {
                    NpgsqlCommand Cmd = new NpgsqlCommand(QueryString, Connection);
                    NpgsqlParameter[] Param = new NpgsqlParameter[1];
                    Param[0] = new NpgsqlParameter("@name", FamilyName);
                    
                    Cmd.Parameters.Add(Param[0]);
                    
                    Cmd.Connection.Open();
                    Cmd.ExecuteNonQuery();

                }


                return "Family added";

            }
            catch (Exception e)
            {

                return "Failed to add family";
            }
        }



    }
}
