using CarStatAppLibrary.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStatAppLibrary.DataAccess
{
    public static class SqliteDataAccess
    {

        public static List<T> LoadData<T>(string sqlStatement, Dictionary<string, object> parameters, string connectionName = "Car")
        {
            DynamicParameters p = parameters.ToDynamicParameters();

            using (IDbConnection cnn = new SQLiteConnection(DataAccessHelpers.LoadConnectionString(connectionName)))
            {
                var rows = cnn.Query<T>(sqlStatement, p);

                return rows.ToList();
            }
        }

        public static void SaveData(string sqlStatement, Dictionary<string, object> parameters, string connectionName = "Car")
        {
            DynamicParameters p = parameters.ToDynamicParameters();

            using (IDbConnection cnn = new SQLiteConnection(DataAccessHelpers.LoadConnectionString(connectionName)))
            {
                cnn.Execute(sqlStatement, p);
            }
        }

        public static DynamicParameters ToDynamicParameters(this Dictionary<string, object> p)
        {
            DynamicParameters output = new DynamicParameters();

            p.ToList().ForEach(x => output.Add(x.Key, x.Value));

            return output;
        }

        public static List<CarModel> CarInventory_GetCars()
        {
            string sql = "SELECT * FROM Car";

            List<CarModel> cars = LoadData<CarModel>(sql, new Dictionary<string, object>());

            return cars;

        }

        public static void CarModel_SaveToDb(CarModel car)
        {

            string sql = "INSERT INTO Car (CarBrand, CarType, HorsePower, Torque, " +
                "Transmission, MaxSpeed, NullToHundred, TrunkProducer, TankCapacity, Weight, " +
                "ConsumptionProducer, ConsumptionAdac, ConsumptionCity, ConsumptionHighWay," +
                "ConsumptionCountryRoad, RangeAdac, InteriorNoise, TrunkAdac)" +
                " VALUES (@CarBrand, @CarType, @HorsePower, @Torque, " +
                "@Transmission, @MaxSpeed, @NullToHundred, @TrunkProducer, @TankCapacity, @Weight, " +
                "@ConsumptionProducer, @ConsumptionAdac, @ConsumptionCity, @ConsumptionHighWay," +
                "@ConsumptionCountryRoad, @RangeAdac, @InteriorNoise, @TrunkAdac)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@CarBrand", car.Brand },
                {"@CarType", car.CarType },
                {"@HorsePower", car.HorsePower },
                {"@Transmission", car.TypeTransmission },
                {"@Torque", car.Torque },
                {"@MaxSpeed", car.MaxSpeed },
                {"@NullToHundred", car.NullToHundred },
                {"@TrunkProducer", car.TrunkProducer },
                {"@TankCapacity", car.TankCapacity },
                {"@Weight", car.Weight },
                {"@ConsumptionProducer", car.ConsumptionProducer },
                {"@ConsumptionAdac", car.ConsumptionAdac},
                {"@ConsumptionCity", car.ConsumptionCity },
                {"@ConsumptionHighWay", car.ConsumptionHighWay},
                {"@ConsumptionCountryRoad", car.ConsumptionCountryRoad},
                {"@RangeAdac", car.RangeAdac},
                {"@InteriorNoise", car.InteriorNoise },
                {"@TrunkAdac", car.TrunkAdac }
            };

            SaveData(sql, parameters);
        }

        public static List<CarModel> GetFilteredCarModel(decimal noise, decimal consumption, int range, int trunk)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@ConsumptionAdac", consumption},
                {"@InteriorNoise", noise },
                {"@RangeAdac", range},
                {"@TrunkAdac", trunk }
            };

            string sqlFilter = @"SELECT * FROM Car 
                                 INNER JOIN Brands ON Car.CarBrand = Brands.id 
                                 INNER JOIN TransmissionType ON Car.Transmission = TransmissionType.id    
                                 WHERE InteriorNoise <= @InteriorNoise AND ConsumptionAdac < @ConsumptionAdac 
                                 AND RangeAdac >= @RangeAdac AND TrunkAdac >= @TrunkAdac;";

            var data = LoadData<CarModel>(sqlFilter, parameters);

            return data;
        }

        public static decimal GetMaxConsumption()
        {
            string sqlconsMax = "SELECT * FROM Car WHERE ConsumptionAdac = (SELECT MAX(ConsumptionAdac) FROM Car)";

            CarModel maxConModel = LoadData<CarModel>(sqlconsMax, new Dictionary<string, object>()).FirstOrDefault();

            return maxConModel.ConsumptionAdac;
        }

        public static decimal GetMaxNoise()
        {
            string sqlinteriorMax = "SELECT* FROM Car WHERE InteriorNoise = (SELECT MAX(InteriorNoise) FROM Car)";

            CarModel maxinteriorModel = LoadData<CarModel>(sqlinteriorMax, new Dictionary<string, object>()).FirstOrDefault();

            return maxinteriorModel.InteriorNoise;
        }

        public static int GetMaxRange()
        {
            string sqlRangeMax = "SELECT* FROM Car WHERE RangeAdac = (SELECT MAX(RangeAdac) FROM Car)";

            CarModel maxRangeModel = SqliteDataAccess.LoadData<CarModel>(sqlRangeMax, new Dictionary<string, object>()).FirstOrDefault();

            return maxRangeModel.RangeAdac;
        }

        public static int GetMaxTrunk()
        {
            string sqlTrunkMax = "SELECT* FROM Car WHERE TrunkAdac = (SELECT MAX(TrunkAdac) FROM Car)";

            CarModel maxTrunkModel = SqliteDataAccess.LoadData<CarModel>(sqlTrunkMax, new Dictionary<string, object>()).FirstOrDefault();

            return maxTrunkModel.TrunkAdac;
        }

        public static decimal GetMinConsumption()
        {
            string sqlconsMin = "SELECT * FROM Car WHERE ConsumptionAdac = (SELECT MIN(ConsumptionAdac) FROM Car)";

            CarModel minConModel = SqliteDataAccess.LoadData<CarModel>(sqlconsMin, new Dictionary<string, object>()).FirstOrDefault();

            return minConModel.ConsumptionAdac;
        }

        public static decimal GetMinNoise()
        {
            string sqlinteriorMin = "SELECT* FROM Car WHERE InteriorNoise = (SELECT MIN(InteriorNoise) FROM Car)";

            CarModel mininteriorModel = SqliteDataAccess.LoadData<CarModel>(sqlinteriorMin, new Dictionary<string, object>()).FirstOrDefault();

            return mininteriorModel.InteriorNoise;
        }

        public static int GetMinRange()
        {
            string sqlRangeMin = "SELECT * FROM Car WHERE RangeAdac = (SELECT MIN(RangeAdac) FROM Car)";

            CarModel minRangeModel = SqliteDataAccess.LoadData<CarModel>(sqlRangeMin, new Dictionary<string, object>()).FirstOrDefault();

            return minRangeModel.RangeAdac;
        }

        public static int GetMinTrunk()
        {
            string sqlTrunkMin = "SELECT* FROM Car WHERE TrunkAdac = (SELECT MIN(TrunkAdac) FROM Car)";

            CarModel minTrunkModel = SqliteDataAccess.LoadData<CarModel>(sqlTrunkMin, new Dictionary<string, object>()).FirstOrDefault();

            return minTrunkModel.TrunkAdac;
        }

        public static List<CarModel> GetMostEffCars()
        {
            List<CarModel> list = new List<CarModel>();

            string sqlQuietest = "SELECT * FROM Car LEFT JOIN Brands ON Car.CarBrand = Brands.id WHERE InteriorNoise = (SELECT MIN(InteriorNoise) FROM Car)";
            string sqlLongest = "SELECT * FROM Car LEFT JOIN Brands ON Car.CarBrand = Brands.id WHERE RangeAdac = (SELECT MAX(RangeAdac) FROM Car)";
            string sqlBiggest = "SELECT * FROM Car LEFT JOIN Brands ON Car.CarBrand = Brands.id WHERE TrunkAdac = (SELECT MAX(TrunkAdac) FROM Car)";
            string sqlEco = "SELECT * FROM Car LEFT JOIN Brands ON Car.CarBrand = Brands.id WHERE ConsumptionAdac = (SELECT MIN(ConsumptionAdac) FROM Car)";

            list.Add(SqliteDataAccess.LoadData<CarModel>(sqlQuietest, new Dictionary<string, object>()).FirstOrDefault());
            list.Add(SqliteDataAccess.LoadData<CarModel>(sqlLongest, new Dictionary<string, object>()).FirstOrDefault());
            list.Add(SqliteDataAccess.LoadData<CarModel>(sqlBiggest, new Dictionary<string, object>()).FirstOrDefault());
            list.Add(SqliteDataAccess.LoadData<CarModel>(sqlEco, new Dictionary<string, object>()).FirstOrDefault());

            return list;
        }

    }
}
