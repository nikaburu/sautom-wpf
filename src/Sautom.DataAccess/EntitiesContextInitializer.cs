using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess
{
    internal sealed class EntitiesContextInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
	    protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

            InitializeDictionaries(context);
            InitializeCountries(context);
            InitClients(context);

            Proposal proposal = new Proposal
                                    {
                                        CourseName = "Уроки английского",
                                        AvailableHouseTypes = context.Set<HousingType>().ToList(),
                                        AvailableIntensities = context.Set<IntensityType>().ToList(),
                                        SchoolName = "Золотой утёнок"
                                    };

            proposal.City = context.Cities.First();
            context.Proposals.Add(proposal);
            context.SaveChanges();
            //for (int i = 0; i < 10; i++)
            //{
            //    proposal.City = context.Cities.First();
            //    context.Proposals.Add(proposal);
            //    context.SaveChanges();

            //    context.Entry(proposal).State = EntityState.Detached;
            //}

            List<Role> roles = new List<Role>
            {
                                       new Role { RoleName = "manager" },
                                       new Role { RoleName = "administrator" }
                                   };

            roles.ForEach(rec => context.Set<Role>().Add(rec));

            List<Manager> managers = new List<Manager>
            {
                                   new Manager { Name = "Pavlova", DisplayName = "Н.С. Павлова", Number = "1", DisplayNameBy = "Павловой Н. С.", AccreditationDate = new DateTime(2012, 5, 2), Position = "Начальник отдела международных программ"},
                                   new Manager { Name = "Zharzhanovich", DisplayName = "М.В. Шаржанович", Number = "2", DisplayNameBy = "Шаржанович М.В.", AccreditationDate = new DateTime(2012, 5, 2), Position = "Специалист по работе с клиентами" },
                                   new Manager { Name = "Seluk", DisplayName = "Н.С. Селюк", Number = "3", DisplayNameBy = "Селюк Н.С.", AccreditationDate = new DateTime(2012, 5, 21), Position = "Специалист по работе с клиентами" },
                                   new Manager { Name = "Lapinskaya", DisplayName = "О.Л. Лапинская", Number = "4", DisplayNameBy = "Лапинской О.Л.", AccreditationDate = new DateTime(2012, 5, 2), Position = "Специалист по работе с клиентами" }
                               };
            managers.ForEach(rec =>
                                 {
                                     Authorization auth = new Authorization
                                     {
                                                        Manager = rec,
                                                        Password = "1234",
                                                        Roles = new List<Role> {roles.First()}
                                                    };
                                     context.Managers.Add(rec);
                                     context.Authorizations.Add(auth);
                                 });
            context.SaveChanges();

            Rate rate = new Rate
            {
                                Date = DateTime.Now.AddYears(-2),
                                RateValue = 10000
                            };
            context.Set<Rate>().Add(rate);
            context.SaveChanges();

            List<Order> orders = new List<Order>
            {
                                 new Order
                                 {
                                         Client = context.Clients.First(),
                                         ResponsibleManager = managers.First(),
                                         Proposal = context.Proposals.First(),
                                         StartDate = DateTime.Now.AddDays(10),
                                         EndDate = DateTime.Now.AddDays(20),
                                         HouseType = context.Set<HousingType>().First(),
                                         Intensity = context.Set<IntensityType>().First()
                                     },
                                 new Order
                                 {
                                         Client = context.Clients.First(),
                                         ResponsibleManager = managers.Last(),
                                         Proposal = context.Proposals.ToList().Last(),
                                         StartDate = DateTime.Now.AddDays(-10),
                                         EndDate = DateTime.Now.AddDays(-5),
                                         HouseType = context.Set<HousingType>().First(),
                                         Intensity = context.Set<IntensityType>().First()
                                     }
                             };

            foreach (Order order in orders)
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

	    private void InitializeCountries(DatabaseContext context)
        {
            Country country = new Country { CountryName = "Англия" };
            List<object> types = new List<object>
            {
                                country,
                                new City {CityName = "Лондон", Country = country},
                                new City {CityName = "Ливерпуль", Country = country},
                                new EmbassyDocument {Country = country, DocumentName = "Паспорт"},
                                new EmbassyDocument {Country = country, DocumentName = "Фото 4х3"}
                            };

            foreach (object type in types)
            {
                context.Set(type.GetType()).Add(type);
            }

            context.SaveChanges();
        }

	    private void InitializeDictionaries(DatabaseContext context)
        {
            List<object> types = new List<object>
            {
                                new HousingType {HousingName = "Семья"},
                                new HousingType {HousingName = "Резиденция"},
                                new HousingType {HousingName = "Отель"},
                                new HousingType {HousingName = "Апартаменты"},
                                new IntensityType {IntensityName = "24/7"},
                                new IntensityType {IntensityName = "Два раза в день"},
                                new IntensityType {IntensityName = "Раз в неделю"}
                            };

            foreach (object type in types)
            {
                context.Set(type.GetType()).Add(type);
            }

            context.SaveChanges();
        }

	    private void InitClients(DatabaseContext context)
        {
            Client client = new Client
            {
                PersonalNumber = Guid.NewGuid().ToString(),
                NameLat = "Grusha Vasiliy",
                FirstName = "Василлий",
                LastName = "Груша",
                MiddleName = "Иванович",
                BirthDate = DateTime.Now.AddYears(-20),
                Address = "Nezavisimosti 25",
                PassportInfo = "MY00101001010",
                PhoneFirst = "(029)444-44-44",
                PhoneSecond = "(029)555-55-55",
                Parent = new ClientParent(),
                PassportFromDate = DateTime.Now.AddYears(-2),
                PassportByDate = DateTime.Now.AddYears(2),
                PassportByWhom = "РОВД города Минска"
            };

            context.Clients.Add(client);
            context.SaveChanges();
        }
    }
}
