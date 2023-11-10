using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IMotorcycle> motorcycleRepository;
        private readonly IRepository<IRider> riderRepository;
        private readonly IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            this.motorcycleRepository = new MotorcycleRepository();
            this.riderRepository = new RiderRepository();
            this.raceRepository = new RaceRepository();
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = null;

            switch (type)
            {
                case "Speed": motorcycle = new SpeedMotorcycle(model, horsePower);
                    break;

                case "Power": motorcycle = new PowerMotorcycle(model, horsePower);
                    break;
                default:
                    break;
            }
            if (motorcycleRepository.GetAll().FirstOrDefault(m => m.Model == model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists,model));
            }

            motorcycleRepository.Add(motorcycle);

            return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, motorcycle.Model);
        }

        public string CreateRider(string riderName)
        {
            IRider rider = new Rider(riderName);

            if (riderRepository.GetAll().FirstOrDefault(r => r.Name == riderName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            riderRepository.Add(rider);

            return string.Format(OutputMessages.RiderCreated, rider.Name);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);

            if (raceRepository.GetAll().FirstOrDefault(r => r.Name == name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            raceRepository.Add(race);

            return string.Format (OutputMessages.RaceCreated, race.Name);
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = riderRepository.GetByName(riderName);
            IMotorcycle motorcycle = motorcycleRepository.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            if (motorcycle == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, rider.Name, motorcycle.Model);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRace race = raceRepository.GetByName(raceName);
            IRider rider = riderRepository.GetByName(riderName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, rider.Name, race.Name);
        }

        public string StartRace(string raceName)
        {
            StringBuilder result = new StringBuilder();

            IRace race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, race.Name, 3));
            }

            List<IRider> ridersWin = new List<IRider>();

            foreach (var rider in race.Riders.OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps)))
            {
                ridersWin.Add(rider);
            }

            IRider firstRider = ridersWin[0];
            IRider secondRider = ridersWin[1];
            IRider thirdRider = ridersWin[2];

            result.AppendLine(string.Format(OutputMessages.RiderFirstPosition, firstRider.Name, race.Name))
            .AppendLine(string.Format(OutputMessages.RiderSecondPosition, secondRider.Name, race.Name))
            .AppendLine(string.Format(OutputMessages.RiderThirdPosition, thirdRider.Name, race.Name));

            raceRepository.Remove(race);

            return result.ToString().TrimEnd();
        }
    }
}
