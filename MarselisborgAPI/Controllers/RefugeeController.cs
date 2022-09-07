using Microsoft.AspNetCore.Mvc;
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
        public RefugeeAPIController(IConfiguration configuration)
        {

            _configuration = configuration;
        }
       

        


        [HttpGet("AllRefugees")]
        public IEnumerable<Refugee> AllRefugees()
        {
            List<Refugee> refugees = new List<Refugee>();
            try
            {
                string queryString = "SELECT * FROM public.flygtning";
                string conn = _configuration.GetConnectionString("db");
               

                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("db")))
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(queryString, connection);
                 
                    cmd.Connection.Open();
                    var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {

                        int? id = null;
                        string name = "not found";
                        int age = 0;
                        int center = 0;
                        int? familiy = null;
                        if (!reader.IsDBNull(0))
                        {
                            id = reader.GetInt32(0);
                        }
                        if (!reader.IsDBNull(1))
                        {
                            name = reader.GetString(1);
                        }
                        if (!reader.IsDBNull(2))
                        {
                            age = reader.GetInt32(2);
                        }
                        if (!reader.IsDBNull(3))
                        {
                            center = reader.GetInt32(3);
                        }
                        if (!reader.IsDBNull(3))
                        {
                            familiy = reader.GetInt32(3);
                        }
                        refugees.Add(new Refugee(id, name, age, center, familiy));
                    }

                    return refugees;
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
            List<RefugeeCenter> centers = new List<RefugeeCenter>();
            


            try
            {
                string queryString = "SELECT * FROM public.opholdssted";
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("db")))
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(queryString, connection);

                    cmd.Connection.Open();
                    var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {

                        centers.Add(new RefugeeCenter(reader.GetInt32(0),reader.GetString(1)));
                    }

                    return centers;
                }

            }
            catch (Exception e)
            {

                throw e;
            }




        }


        [HttpGet("AllRefugeesFromCenter/{centerid}")]
        public IEnumerable<Refugee> AllRefugeesFromCenter(int centerid)
        {
            List<Refugee> refugees = new List<Refugee>();
            try
            {
                string queryString = "SELECT * FROM public.flygtning where flygtning.center = @ID";
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("db")))
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(queryString, connection);
                    NpgsqlParameter[] param = new NpgsqlParameter[1];
                    param[0] = new NpgsqlParameter("@ID", centerid);

                    cmd.Parameters.Add(param[0]);

                    cmd.Connection.Open();
                    var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {

                        int? id = null;
                        string name = "not found";
                        int age = 0;
                        int center = 0;
                        int? familiy = null;
                        if (!reader.IsDBNull(0))
                        {
                            id = reader.GetInt32(0);
                        }
                        if (!reader.IsDBNull(1))
                        {
                            name = reader.GetString(1);
                        }
                        if (!reader.IsDBNull(2))
                        {
                            age = reader.GetInt32(2);
                        }
                        if (!reader.IsDBNull(3))
                        {
                            center = reader.GetInt32(3);
                        } if (!reader.IsDBNull(4))
                        {
                            familiy = reader.GetInt32(4);
                        }

                        refugees.Add(new Refugee(id, name, age, center, familiy));
                    }

                    return refugees;
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
            List<Refugee> refugees = new List<Refugee>();
            try
            {
                int? id = null;
                string queryString = "SELECT familieID FROM public.flygtning where flygtning.flygtning_id=@ID";
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("db")))
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(queryString, connection);
                    NpgsqlParameter[] param = new NpgsqlParameter[1];
                    param[0] = new NpgsqlParameter("@ID", RefugeeID);

                    cmd.Parameters.Add(param[0]);

                    cmd.Connection.Open();
                    var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {

                        
                        if (!reader.IsDBNull(0))
                        {
                            id = reader.GetInt32(0);
                        }
                    }

                 
                }

                if (id!=null)
                {

                    string findfamaliy = "SELECT * FROM public.flygtning where flygtning.familieID=@ID";
                    using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("db")))
                    {
                        NpgsqlCommand cmd = new NpgsqlCommand(findfamaliy, connection);
                        NpgsqlParameter[] param = new NpgsqlParameter[1];
                        param[0] = new NpgsqlParameter("@ID", id);
              
                        cmd.Parameters.Add(param[0]);

                        cmd.Connection.Open();
                       var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {

                            int? fid = null;
                            string name = "not found";
                            int age = 0;
                            int center = 0;
                            int? familiy = null;
                            if (!reader.IsDBNull(0))
                            {
                                fid = reader.GetInt32(0);
                            }
                            if (!reader.IsDBNull(1))
                            {
                                name = reader.GetString(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                age = reader.GetInt32(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                center = reader.GetInt32(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                familiy = reader.GetInt32(4);
                            }

                            refugees.Add(new Refugee(fid, name, age, center, familiy));
                        }
            
                    }

                }
                        return refugees;

            }
            catch (Exception e)
            {

                throw e;
            }

        }



        [HttpPost("AddRefugee")]
        public string AddRefugee([FromBody]RefugeeDTO person)
        {
            try
            {
                string queryString = "INSERT INTO public.flygtning(navn, alder, center,familieID)	VALUES( @name, @age, @center,@familiy); ";
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("db")))
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(queryString, connection);
                    NpgsqlParameter[] param = new NpgsqlParameter[4];
                    param[0] = new NpgsqlParameter("@name", person.Navn);
                    param[1] = new NpgsqlParameter("@age", person.Alder);
                    param[2] = new NpgsqlParameter("@center",person.FlygtningeCenterID);
                    param[3] = new NpgsqlParameter("@familiy",person.FamilieID);
                    cmd.Parameters.Add(param[0]);
                    cmd.Parameters.Add(param[1]);
                    cmd.Parameters.Add(param[2]);
                    cmd.Parameters.Add(param[3]);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }


                return "Refugee added";  

            }
            catch (Exception e)
            {

           

                return "Failed to add Refugee";
            }
        }



        [HttpPost("AddFamily/{Familienavn}")]
        public string AddFamily(string Familienavn)
        {
            try
            {
                string queryString = "INSERT INTO public.familie(name)	VALUES( @name); ";
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("db")))
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(queryString, connection);
                    NpgsqlParameter[] param = new NpgsqlParameter[1];
                    param[0] = new NpgsqlParameter("@name", Familienavn);
                    
                    cmd.Parameters.Add(param[0]);
                    
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
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
