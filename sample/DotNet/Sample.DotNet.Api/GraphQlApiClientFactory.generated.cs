namespace Sample.DotNet.Api
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Sample.DotNet.Api.Infra;

    #region Dtos

    public class FilmsConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<FilmsEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<FilmDto> Films { get; set; }
    }

    public class PageInfoDto
    {
        public bool? HasNextPage { get; set; }
        public bool? HasPreviousPage { get; set; }
        public string StartCursor { get; set; }
        public string EndCursor { get; set; }
    }

    public class FilmsEdgeDto
    {
        public FilmDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class FilmDto
    {
        public string Title { get; set; }
        public int? EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public List<string> Producers { get; set; }
        public string ReleaseDate { get; set; }
        public FilmSpeciesConnectionDto SpeciesConnection { get; set; }
        public FilmStarshipsConnectionDto StarshipConnection { get; set; }
        public FilmVehiclesConnectionDto VehicleConnection { get; set; }
        public FilmCharactersConnectionDto CharacterConnection { get; set; }
        public FilmPlanetsConnectionDto PlanetConnection { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Id { get; set; }
    }

    public class NodeDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int? EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public List<string> Producers { get; set; }
        public string ReleaseDate { get; set; }
        public FilmSpeciesConnectionDto SpeciesConnection { get; set; }
        public FilmStarshipsConnectionDto StarshipConnection { get; set; }
        public FilmVehiclesConnectionDto VehicleConnection { get; set; }
        public FilmCharactersConnectionDto CharacterConnection { get; set; }
        public FilmPlanetsConnectionDto PlanetConnection { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public float? AverageHeight { get; set; }
        public int? AverageLifespan { get; set; }
        public List<string> EyeColors { get; set; }
        public List<string> HairColors { get; set; }
        public List<string> SkinColors { get; set; }
        public string Language { get; set; }
        public PlanetDto Homeworld { get; set; }
        public SpeciesPeopleConnectionDto PersonConnection { get; set; }
        public SpeciesFilmsConnectionDto FilmConnection { get; set; }
        public int? Diameter { get; set; }
        public int? RotationPeriod { get; set; }
        public int? OrbitalPeriod { get; set; }
        public string Gravity { get; set; }
        public float? Population { get; set; }
        public List<string> Climates { get; set; }
        public List<string> Terrains { get; set; }
        public float? SurfaceWater { get; set; }
        public PlanetResidentsConnectionDto ResidentConnection { get; set; }
        public string BirthYear { get; set; }
        public string EyeColor { get; set; }
        public string Gender { get; set; }
        public string HairColor { get; set; }
        public int? Height { get; set; }
        public float? Mass { get; set; }
        public string SkinColor { get; set; }
        public SpeciesDto Species { get; set; }
        public string Model { get; set; }
        public string StarshipClass { get; set; }
        public List<string> Manufacturers { get; set; }
        public float? CostInCredits { get; set; }
        public float? Length { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public int? MaxAtmospheringSpeed { get; set; }
        public float? HyperdriveRating { get; set; }
        public int? Mglt { get; set; }
        public float? CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public StarshipPilotsConnectionDto PilotConnection { get; set; }
        public string VehicleClass { get; set; }
    }

    public class FilmSpeciesConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<FilmSpeciesEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<SpeciesDto> Species { get; set; }
    }

    public class FilmSpeciesEdgeDto
    {
        public SpeciesDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class SpeciesDto
    {
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public float? AverageHeight { get; set; }
        public int? AverageLifespan { get; set; }
        public List<string> EyeColors { get; set; }
        public List<string> HairColors { get; set; }
        public List<string> SkinColors { get; set; }
        public string Language { get; set; }
        public PlanetDto Homeworld { get; set; }
        public SpeciesPeopleConnectionDto PersonConnection { get; set; }
        public SpeciesFilmsConnectionDto FilmConnection { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Id { get; set; }
    }

    public class PlanetDto
    {
        public string Name { get; set; }
        public int? Diameter { get; set; }
        public int? RotationPeriod { get; set; }
        public int? OrbitalPeriod { get; set; }
        public string Gravity { get; set; }
        public float? Population { get; set; }
        public List<string> Climates { get; set; }
        public List<string> Terrains { get; set; }
        public float? SurfaceWater { get; set; }
        public PlanetResidentsConnectionDto ResidentConnection { get; set; }
        public PlanetFilmsConnectionDto FilmConnection { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Id { get; set; }
    }

    public class PlanetResidentsConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<PlanetResidentsEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<PersonDto> Residents { get; set; }
    }

    public class PlanetResidentsEdgeDto
    {
        public PersonDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class PersonDto
    {
        public string Name { get; set; }
        public string BirthYear { get; set; }
        public string EyeColor { get; set; }
        public string Gender { get; set; }
        public string HairColor { get; set; }
        public int? Height { get; set; }
        public float? Mass { get; set; }
        public string SkinColor { get; set; }
        public PlanetDto Homeworld { get; set; }
        public PersonFilmsConnectionDto FilmConnection { get; set; }
        public SpeciesDto Species { get; set; }
        public PersonStarshipsConnectionDto StarshipConnection { get; set; }
        public PersonVehiclesConnectionDto VehicleConnection { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Id { get; set; }
    }

    public class PersonFilmsConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<PersonFilmsEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<FilmDto> Films { get; set; }
    }

    public class PersonFilmsEdgeDto
    {
        public FilmDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class PersonStarshipsConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<PersonStarshipsEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<StarshipDto> Starships { get; set; }
    }

    public class PersonStarshipsEdgeDto
    {
        public StarshipDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class StarshipDto
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string StarshipClass { get; set; }
        public List<string> Manufacturers { get; set; }
        public float? CostInCredits { get; set; }
        public float? Length { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public int? MaxAtmospheringSpeed { get; set; }
        public float? HyperdriveRating { get; set; }
        public int? Mglt { get; set; }
        public float? CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public StarshipPilotsConnectionDto PilotConnection { get; set; }
        public StarshipFilmsConnectionDto FilmConnection { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Id { get; set; }
    }

    public class StarshipPilotsConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<StarshipPilotsEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<PersonDto> Pilots { get; set; }
    }

    public class StarshipPilotsEdgeDto
    {
        public PersonDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class StarshipFilmsConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<StarshipFilmsEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<FilmDto> Films { get; set; }
    }

    public class StarshipFilmsEdgeDto
    {
        public FilmDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class PersonVehiclesConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<PersonVehiclesEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<VehicleDto> Vehicles { get; set; }
    }

    public class PersonVehiclesEdgeDto
    {
        public VehicleDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class VehicleDto
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string VehicleClass { get; set; }
        public List<string> Manufacturers { get; set; }
        public int? CostInCredits { get; set; }
        public float? Length { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public int? MaxAtmospheringSpeed { get; set; }
        public int? CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public VehiclePilotsConnectionDto PilotConnection { get; set; }
        public VehicleFilmsConnectionDto FilmConnection { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Id { get; set; }
    }

    public class VehiclePilotsConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<VehiclePilotsEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<PersonDto> Pilots { get; set; }
    }

    public class VehiclePilotsEdgeDto
    {
        public PersonDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class VehicleFilmsConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<VehicleFilmsEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<FilmDto> Films { get; set; }
    }

    public class VehicleFilmsEdgeDto
    {
        public FilmDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class PlanetFilmsConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<PlanetFilmsEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<FilmDto> Films { get; set; }
    }

    public class PlanetFilmsEdgeDto
    {
        public FilmDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class SpeciesPeopleConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<SpeciesPeopleEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<PersonDto> People { get; set; }
    }

    public class SpeciesPeopleEdgeDto
    {
        public PersonDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class SpeciesFilmsConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<SpeciesFilmsEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<FilmDto> Films { get; set; }
    }

    public class SpeciesFilmsEdgeDto
    {
        public FilmDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class FilmStarshipsConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<FilmStarshipsEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<StarshipDto> Starships { get; set; }
    }

    public class FilmStarshipsEdgeDto
    {
        public StarshipDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class FilmVehiclesConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<FilmVehiclesEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<VehicleDto> Vehicles { get; set; }
    }

    public class FilmVehiclesEdgeDto
    {
        public VehicleDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class FilmCharactersConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<FilmCharactersEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<PersonDto> Characters { get; set; }
    }

    public class FilmCharactersEdgeDto
    {
        public PersonDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class FilmPlanetsConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<FilmPlanetsEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<PlanetDto> Planets { get; set; }
    }

    public class FilmPlanetsEdgeDto
    {
        public PlanetDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class PeopleConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<PeopleEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<PersonDto> People { get; set; }
    }

    public class PeopleEdgeDto
    {
        public PersonDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class PlanetsConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<PlanetsEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<PlanetDto> Planets { get; set; }
    }

    public class PlanetsEdgeDto
    {
        public PlanetDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class SpeciesConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<SpeciesEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<SpeciesDto> Species { get; set; }
    }

    public class SpeciesEdgeDto
    {
        public SpeciesDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class StarshipsConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<StarshipsEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<StarshipDto> Starships { get; set; }
    }

    public class StarshipsEdgeDto
    {
        public StarshipDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class VehiclesConnectionDto
    {
        public PageInfoDto PageInfo { get; set; }
        public List<VehiclesEdgeDto> Edges { get; set; }
        public int? TotalCount { get; set; }
        public List<VehicleDto> Vehicles { get; set; }
    }

    public class VehiclesEdgeDto
    {
        public VehicleDto Node { get; set; }
        public string Cursor { get; set; }
    }

    public class RootDto
    {
        public FilmsConnectionDto AllFilms { get; set; }
        public FilmDto Film { get; set; }
        public PeopleConnectionDto AllPeople { get; set; }
        public PersonDto Person { get; set; }
        public PlanetsConnectionDto AllPlanets { get; set; }
        public PlanetDto Planet { get; set; }
        public SpeciesConnectionDto AllSpecies { get; set; }
        public SpeciesDto Species { get; set; }
        public StarshipsConnectionDto AllStarships { get; set; }
        public StarshipDto Starship { get; set; }
        public VehiclesConnectionDto AllVehicles { get; set; }
        public VehicleDto Vehicle { get; set; }
        public NodeDto Node { get; set; }
    }

    #endregion

    #region Builders

    public class FilmsConnectionBuilder : TypeBase
    {
        public FilmsConnectionBuilder() : base("FilmsConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, FilmsConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<FilmsEdgeBuilder>, FilmsConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new FilmsEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public FilmsConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<FilmBuilder>, FilmsConnectionBuilder> Films()
        {
            IncludingField("films");
            return __ =>
            {
                var _ = new FilmBuilder();
                __(_);
                IncludeField(
                    "films",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class PageInfoBuilder : TypeBase
    {
        public PageInfoBuilder() : base("PageInfo")
        {
        }


        public PageInfoBuilder HasNextPage()
        {
            IncludeField(
                "hasNextPage",
                new List<Argument>(0),
                null);
            return this;
        }

        public PageInfoBuilder HasPreviousPage()
        {
            IncludeField(
                "hasPreviousPage",
                new List<Argument>(0),
                null);
            return this;
        }

        public PageInfoBuilder StartCursor()
        {
            IncludeField(
                "startCursor",
                new List<Argument>(0),
                null);
            return this;
        }

        public PageInfoBuilder EndCursor()
        {
            IncludeField(
                "endCursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class FilmsEdgeBuilder : TypeBase
    {
        public FilmsEdgeBuilder() : base("FilmsEdge")
        {
        }


        public Func<Action<FilmBuilder>, FilmsEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new FilmBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public FilmsEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class FilmBuilder : TypeBase
    {
        public FilmBuilder() : base("Film")
        {
        }


        public FilmBuilder Title()
        {
            IncludeField(
                "title",
                new List<Argument>(0),
                null);
            return this;
        }

        public FilmBuilder EpisodeId()
        {
            IncludeField(
                "episodeID",
                new List<Argument>(0),
                null);
            return this;
        }

        public FilmBuilder OpeningCrawl()
        {
            IncludeField(
                "openingCrawl",
                new List<Argument>(0),
                null);
            return this;
        }

        public FilmBuilder Director()
        {
            IncludeField(
                "director",
                new List<Argument>(0),
                null);
            return this;
        }

        public FilmBuilder Producers()
        {
            IncludeField(
                "producers",
                new List<Argument>(0),
                null);
            return this;
        }

        public FilmBuilder ReleaseDate()
        {
            IncludeField(
                "releaseDate",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<FilmSpeciesConnectionBuilder>, FilmBuilder> SpeciesConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("speciesConnection");
            return __ =>
            {
                var _ = new FilmSpeciesConnectionBuilder();
                __(_);
                IncludeField(
                    "speciesConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<FilmStarshipsConnectionBuilder>, FilmBuilder> StarshipConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("starshipConnection");
            return __ =>
            {
                var _ = new FilmStarshipsConnectionBuilder();
                __(_);
                IncludeField(
                    "starshipConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<FilmVehiclesConnectionBuilder>, FilmBuilder> VehicleConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("vehicleConnection");
            return __ =>
            {
                var _ = new FilmVehiclesConnectionBuilder();
                __(_);
                IncludeField(
                    "vehicleConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<FilmCharactersConnectionBuilder>, FilmBuilder> CharacterConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("characterConnection");
            return __ =>
            {
                var _ = new FilmCharactersConnectionBuilder();
                __(_);
                IncludeField(
                    "characterConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<FilmPlanetsConnectionBuilder>, FilmBuilder> PlanetConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("planetConnection");
            return __ =>
            {
                var _ = new FilmPlanetsConnectionBuilder();
                __(_);
                IncludeField(
                    "planetConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public FilmBuilder Created()
        {
            IncludeField(
                "created",
                new List<Argument>(0),
                null);
            return this;
        }

        public FilmBuilder Edited()
        {
            IncludeField(
                "edited",
                new List<Argument>(0),
                null);
            return this;
        }

        public FilmBuilder Id()
        {
            IncludeField(
                "id",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class NodeBuilder : TypeBase
    {
        public NodeBuilder() : base("Node")
        {
        }


        public NodeBuilder Id()
        {
            IncludeField(
                "id",
                new List<Argument>(0),
                null);
            return this;
        }

        public NodeBuilder OnFilm(Action<FilmBuilder> setupAction)
        {
            var type = new FilmBuilder();
            setupAction(type);
            IncludeOnTypeField(type);
            return this;
        }

        public NodeBuilder OnSpecies(Action<SpeciesBuilder> setupAction)
        {
            var type = new SpeciesBuilder();
            setupAction(type);
            IncludeOnTypeField(type);
            return this;
        }

        public NodeBuilder OnPlanet(Action<PlanetBuilder> setupAction)
        {
            var type = new PlanetBuilder();
            setupAction(type);
            IncludeOnTypeField(type);
            return this;
        }

        public NodeBuilder OnPerson(Action<PersonBuilder> setupAction)
        {
            var type = new PersonBuilder();
            setupAction(type);
            IncludeOnTypeField(type);
            return this;
        }

        public NodeBuilder OnStarship(Action<StarshipBuilder> setupAction)
        {
            var type = new StarshipBuilder();
            setupAction(type);
            IncludeOnTypeField(type);
            return this;
        }

        public NodeBuilder OnVehicle(Action<VehicleBuilder> setupAction)
        {
            var type = new VehicleBuilder();
            setupAction(type);
            IncludeOnTypeField(type);
            return this;
        }
    }

    public class FilmSpeciesConnectionBuilder : TypeBase
    {
        public FilmSpeciesConnectionBuilder() : base("FilmSpeciesConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, FilmSpeciesConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<FilmSpeciesEdgeBuilder>, FilmSpeciesConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new FilmSpeciesEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public FilmSpeciesConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<SpeciesBuilder>, FilmSpeciesConnectionBuilder> Species()
        {
            IncludingField("species");
            return __ =>
            {
                var _ = new SpeciesBuilder();
                __(_);
                IncludeField(
                    "species",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class FilmSpeciesEdgeBuilder : TypeBase
    {
        public FilmSpeciesEdgeBuilder() : base("FilmSpeciesEdge")
        {
        }


        public Func<Action<SpeciesBuilder>, FilmSpeciesEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new SpeciesBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public FilmSpeciesEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class SpeciesBuilder : TypeBase
    {
        public SpeciesBuilder() : base("Species")
        {
        }


        public SpeciesBuilder Name()
        {
            IncludeField(
                "name",
                new List<Argument>(0),
                null);
            return this;
        }

        public SpeciesBuilder Classification()
        {
            IncludeField(
                "classification",
                new List<Argument>(0),
                null);
            return this;
        }

        public SpeciesBuilder Designation()
        {
            IncludeField(
                "designation",
                new List<Argument>(0),
                null);
            return this;
        }

        public SpeciesBuilder AverageHeight()
        {
            IncludeField(
                "averageHeight",
                new List<Argument>(0),
                null);
            return this;
        }

        public SpeciesBuilder AverageLifespan()
        {
            IncludeField(
                "averageLifespan",
                new List<Argument>(0),
                null);
            return this;
        }

        public SpeciesBuilder EyeColors()
        {
            IncludeField(
                "eyeColors",
                new List<Argument>(0),
                null);
            return this;
        }

        public SpeciesBuilder HairColors()
        {
            IncludeField(
                "hairColors",
                new List<Argument>(0),
                null);
            return this;
        }

        public SpeciesBuilder SkinColors()
        {
            IncludeField(
                "skinColors",
                new List<Argument>(0),
                null);
            return this;
        }

        public SpeciesBuilder Language()
        {
            IncludeField(
                "language",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<PlanetBuilder>, SpeciesBuilder> Homeworld()
        {
            IncludingField("homeworld");
            return __ =>
            {
                var _ = new PlanetBuilder();
                __(_);
                IncludeField(
                    "homeworld",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<SpeciesPeopleConnectionBuilder>, SpeciesBuilder> PersonConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("personConnection");
            return __ =>
            {
                var _ = new SpeciesPeopleConnectionBuilder();
                __(_);
                IncludeField(
                    "personConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<SpeciesFilmsConnectionBuilder>, SpeciesBuilder> FilmConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("filmConnection");
            return __ =>
            {
                var _ = new SpeciesFilmsConnectionBuilder();
                __(_);
                IncludeField(
                    "filmConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public SpeciesBuilder Created()
        {
            IncludeField(
                "created",
                new List<Argument>(0),
                null);
            return this;
        }

        public SpeciesBuilder Edited()
        {
            IncludeField(
                "edited",
                new List<Argument>(0),
                null);
            return this;
        }

        public SpeciesBuilder Id()
        {
            IncludeField(
                "id",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class PlanetBuilder : TypeBase
    {
        public PlanetBuilder() : base("Planet")
        {
        }


        public PlanetBuilder Name()
        {
            IncludeField(
                "name",
                new List<Argument>(0),
                null);
            return this;
        }

        public PlanetBuilder Diameter()
        {
            IncludeField(
                "diameter",
                new List<Argument>(0),
                null);
            return this;
        }

        public PlanetBuilder RotationPeriod()
        {
            IncludeField(
                "rotationPeriod",
                new List<Argument>(0),
                null);
            return this;
        }

        public PlanetBuilder OrbitalPeriod()
        {
            IncludeField(
                "orbitalPeriod",
                new List<Argument>(0),
                null);
            return this;
        }

        public PlanetBuilder Gravity()
        {
            IncludeField(
                "gravity",
                new List<Argument>(0),
                null);
            return this;
        }

        public PlanetBuilder Population()
        {
            IncludeField(
                "population",
                new List<Argument>(0),
                null);
            return this;
        }

        public PlanetBuilder Climates()
        {
            IncludeField(
                "climates",
                new List<Argument>(0),
                null);
            return this;
        }

        public PlanetBuilder Terrains()
        {
            IncludeField(
                "terrains",
                new List<Argument>(0),
                null);
            return this;
        }

        public PlanetBuilder SurfaceWater()
        {
            IncludeField(
                "surfaceWater",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<PlanetResidentsConnectionBuilder>, PlanetBuilder> ResidentConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("residentConnection");
            return __ =>
            {
                var _ = new PlanetResidentsConnectionBuilder();
                __(_);
                IncludeField(
                    "residentConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<PlanetFilmsConnectionBuilder>, PlanetBuilder> FilmConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("filmConnection");
            return __ =>
            {
                var _ = new PlanetFilmsConnectionBuilder();
                __(_);
                IncludeField(
                    "filmConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public PlanetBuilder Created()
        {
            IncludeField(
                "created",
                new List<Argument>(0),
                null);
            return this;
        }

        public PlanetBuilder Edited()
        {
            IncludeField(
                "edited",
                new List<Argument>(0),
                null);
            return this;
        }

        public PlanetBuilder Id()
        {
            IncludeField(
                "id",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class PlanetResidentsConnectionBuilder : TypeBase
    {
        public PlanetResidentsConnectionBuilder() : base("PlanetResidentsConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, PlanetResidentsConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<PlanetResidentsEdgeBuilder>, PlanetResidentsConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new PlanetResidentsEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public PlanetResidentsConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<PersonBuilder>, PlanetResidentsConnectionBuilder> Residents()
        {
            IncludingField("residents");
            return __ =>
            {
                var _ = new PersonBuilder();
                __(_);
                IncludeField(
                    "residents",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class PlanetResidentsEdgeBuilder : TypeBase
    {
        public PlanetResidentsEdgeBuilder() : base("PlanetResidentsEdge")
        {
        }


        public Func<Action<PersonBuilder>, PlanetResidentsEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new PersonBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public PlanetResidentsEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class PersonBuilder : TypeBase
    {
        public PersonBuilder() : base("Person")
        {
        }


        public PersonBuilder Name()
        {
            IncludeField(
                "name",
                new List<Argument>(0),
                null);
            return this;
        }

        public PersonBuilder BirthYear()
        {
            IncludeField(
                "birthYear",
                new List<Argument>(0),
                null);
            return this;
        }

        public PersonBuilder EyeColor()
        {
            IncludeField(
                "eyeColor",
                new List<Argument>(0),
                null);
            return this;
        }

        public PersonBuilder Gender()
        {
            IncludeField(
                "gender",
                new List<Argument>(0),
                null);
            return this;
        }

        public PersonBuilder HairColor()
        {
            IncludeField(
                "hairColor",
                new List<Argument>(0),
                null);
            return this;
        }

        public PersonBuilder Height()
        {
            IncludeField(
                "height",
                new List<Argument>(0),
                null);
            return this;
        }

        public PersonBuilder Mass()
        {
            IncludeField(
                "mass",
                new List<Argument>(0),
                null);
            return this;
        }

        public PersonBuilder SkinColor()
        {
            IncludeField(
                "skinColor",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<PlanetBuilder>, PersonBuilder> Homeworld()
        {
            IncludingField("homeworld");
            return __ =>
            {
                var _ = new PlanetBuilder();
                __(_);
                IncludeField(
                    "homeworld",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<PersonFilmsConnectionBuilder>, PersonBuilder> FilmConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("filmConnection");
            return __ =>
            {
                var _ = new PersonFilmsConnectionBuilder();
                __(_);
                IncludeField(
                    "filmConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<SpeciesBuilder>, PersonBuilder> Species()
        {
            IncludingField("species");
            return __ =>
            {
                var _ = new SpeciesBuilder();
                __(_);
                IncludeField(
                    "species",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<PersonStarshipsConnectionBuilder>, PersonBuilder> StarshipConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("starshipConnection");
            return __ =>
            {
                var _ = new PersonStarshipsConnectionBuilder();
                __(_);
                IncludeField(
                    "starshipConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<PersonVehiclesConnectionBuilder>, PersonBuilder> VehicleConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("vehicleConnection");
            return __ =>
            {
                var _ = new PersonVehiclesConnectionBuilder();
                __(_);
                IncludeField(
                    "vehicleConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public PersonBuilder Created()
        {
            IncludeField(
                "created",
                new List<Argument>(0),
                null);
            return this;
        }

        public PersonBuilder Edited()
        {
            IncludeField(
                "edited",
                new List<Argument>(0),
                null);
            return this;
        }

        public PersonBuilder Id()
        {
            IncludeField(
                "id",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class PersonFilmsConnectionBuilder : TypeBase
    {
        public PersonFilmsConnectionBuilder() : base("PersonFilmsConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, PersonFilmsConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<PersonFilmsEdgeBuilder>, PersonFilmsConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new PersonFilmsEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public PersonFilmsConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<FilmBuilder>, PersonFilmsConnectionBuilder> Films()
        {
            IncludingField("films");
            return __ =>
            {
                var _ = new FilmBuilder();
                __(_);
                IncludeField(
                    "films",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class PersonFilmsEdgeBuilder : TypeBase
    {
        public PersonFilmsEdgeBuilder() : base("PersonFilmsEdge")
        {
        }


        public Func<Action<FilmBuilder>, PersonFilmsEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new FilmBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public PersonFilmsEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class PersonStarshipsConnectionBuilder : TypeBase
    {
        public PersonStarshipsConnectionBuilder() : base("PersonStarshipsConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, PersonStarshipsConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<PersonStarshipsEdgeBuilder>, PersonStarshipsConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new PersonStarshipsEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public PersonStarshipsConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<StarshipBuilder>, PersonStarshipsConnectionBuilder> Starships()
        {
            IncludingField("starships");
            return __ =>
            {
                var _ = new StarshipBuilder();
                __(_);
                IncludeField(
                    "starships",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class PersonStarshipsEdgeBuilder : TypeBase
    {
        public PersonStarshipsEdgeBuilder() : base("PersonStarshipsEdge")
        {
        }


        public Func<Action<StarshipBuilder>, PersonStarshipsEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new StarshipBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public PersonStarshipsEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class StarshipBuilder : TypeBase
    {
        public StarshipBuilder() : base("Starship")
        {
        }


        public StarshipBuilder Name()
        {
            IncludeField(
                "name",
                new List<Argument>(0),
                null);
            return this;
        }

        public StarshipBuilder Model()
        {
            IncludeField(
                "model",
                new List<Argument>(0),
                null);
            return this;
        }

        public StarshipBuilder StarshipClass()
        {
            IncludeField(
                "starshipClass",
                new List<Argument>(0),
                null);
            return this;
        }

        public StarshipBuilder Manufacturers()
        {
            IncludeField(
                "manufacturers",
                new List<Argument>(0),
                null);
            return this;
        }

        public StarshipBuilder CostInCredits()
        {
            IncludeField(
                "costInCredits",
                new List<Argument>(0),
                null);
            return this;
        }

        public StarshipBuilder Length()
        {
            IncludeField(
                "length",
                new List<Argument>(0),
                null);
            return this;
        }

        public StarshipBuilder Crew()
        {
            IncludeField(
                "crew",
                new List<Argument>(0),
                null);
            return this;
        }

        public StarshipBuilder Passengers()
        {
            IncludeField(
                "passengers",
                new List<Argument>(0),
                null);
            return this;
        }

        public StarshipBuilder MaxAtmospheringSpeed()
        {
            IncludeField(
                "maxAtmospheringSpeed",
                new List<Argument>(0),
                null);
            return this;
        }

        public StarshipBuilder HyperdriveRating()
        {
            IncludeField(
                "hyperdriveRating",
                new List<Argument>(0),
                null);
            return this;
        }

        public StarshipBuilder Mglt()
        {
            IncludeField(
                "MGLT",
                new List<Argument>(0),
                null);
            return this;
        }

        public StarshipBuilder CargoCapacity()
        {
            IncludeField(
                "cargoCapacity",
                new List<Argument>(0),
                null);
            return this;
        }

        public StarshipBuilder Consumables()
        {
            IncludeField(
                "consumables",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<StarshipPilotsConnectionBuilder>, StarshipBuilder> PilotConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("pilotConnection");
            return __ =>
            {
                var _ = new StarshipPilotsConnectionBuilder();
                __(_);
                IncludeField(
                    "pilotConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<StarshipFilmsConnectionBuilder>, StarshipBuilder> FilmConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("filmConnection");
            return __ =>
            {
                var _ = new StarshipFilmsConnectionBuilder();
                __(_);
                IncludeField(
                    "filmConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public StarshipBuilder Created()
        {
            IncludeField(
                "created",
                new List<Argument>(0),
                null);
            return this;
        }

        public StarshipBuilder Edited()
        {
            IncludeField(
                "edited",
                new List<Argument>(0),
                null);
            return this;
        }

        public StarshipBuilder Id()
        {
            IncludeField(
                "id",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class StarshipPilotsConnectionBuilder : TypeBase
    {
        public StarshipPilotsConnectionBuilder() : base("StarshipPilotsConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, StarshipPilotsConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<StarshipPilotsEdgeBuilder>, StarshipPilotsConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new StarshipPilotsEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public StarshipPilotsConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<PersonBuilder>, StarshipPilotsConnectionBuilder> Pilots()
        {
            IncludingField("pilots");
            return __ =>
            {
                var _ = new PersonBuilder();
                __(_);
                IncludeField(
                    "pilots",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class StarshipPilotsEdgeBuilder : TypeBase
    {
        public StarshipPilotsEdgeBuilder() : base("StarshipPilotsEdge")
        {
        }


        public Func<Action<PersonBuilder>, StarshipPilotsEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new PersonBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public StarshipPilotsEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class StarshipFilmsConnectionBuilder : TypeBase
    {
        public StarshipFilmsConnectionBuilder() : base("StarshipFilmsConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, StarshipFilmsConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<StarshipFilmsEdgeBuilder>, StarshipFilmsConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new StarshipFilmsEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public StarshipFilmsConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<FilmBuilder>, StarshipFilmsConnectionBuilder> Films()
        {
            IncludingField("films");
            return __ =>
            {
                var _ = new FilmBuilder();
                __(_);
                IncludeField(
                    "films",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class StarshipFilmsEdgeBuilder : TypeBase
    {
        public StarshipFilmsEdgeBuilder() : base("StarshipFilmsEdge")
        {
        }


        public Func<Action<FilmBuilder>, StarshipFilmsEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new FilmBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public StarshipFilmsEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class PersonVehiclesConnectionBuilder : TypeBase
    {
        public PersonVehiclesConnectionBuilder() : base("PersonVehiclesConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, PersonVehiclesConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<PersonVehiclesEdgeBuilder>, PersonVehiclesConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new PersonVehiclesEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public PersonVehiclesConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<VehicleBuilder>, PersonVehiclesConnectionBuilder> Vehicles()
        {
            IncludingField("vehicles");
            return __ =>
            {
                var _ = new VehicleBuilder();
                __(_);
                IncludeField(
                    "vehicles",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class PersonVehiclesEdgeBuilder : TypeBase
    {
        public PersonVehiclesEdgeBuilder() : base("PersonVehiclesEdge")
        {
        }


        public Func<Action<VehicleBuilder>, PersonVehiclesEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new VehicleBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public PersonVehiclesEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class VehicleBuilder : TypeBase
    {
        public VehicleBuilder() : base("Vehicle")
        {
        }


        public VehicleBuilder Name()
        {
            IncludeField(
                "name",
                new List<Argument>(0),
                null);
            return this;
        }

        public VehicleBuilder Model()
        {
            IncludeField(
                "model",
                new List<Argument>(0),
                null);
            return this;
        }

        public VehicleBuilder VehicleClass()
        {
            IncludeField(
                "vehicleClass",
                new List<Argument>(0),
                null);
            return this;
        }

        public VehicleBuilder Manufacturers()
        {
            IncludeField(
                "manufacturers",
                new List<Argument>(0),
                null);
            return this;
        }

        public VehicleBuilder CostInCredits()
        {
            IncludeField(
                "costInCredits",
                new List<Argument>(0),
                null);
            return this;
        }

        public VehicleBuilder Length()
        {
            IncludeField(
                "length",
                new List<Argument>(0),
                null);
            return this;
        }

        public VehicleBuilder Crew()
        {
            IncludeField(
                "crew",
                new List<Argument>(0),
                null);
            return this;
        }

        public VehicleBuilder Passengers()
        {
            IncludeField(
                "passengers",
                new List<Argument>(0),
                null);
            return this;
        }

        public VehicleBuilder MaxAtmospheringSpeed()
        {
            IncludeField(
                "maxAtmospheringSpeed",
                new List<Argument>(0),
                null);
            return this;
        }

        public VehicleBuilder CargoCapacity()
        {
            IncludeField(
                "cargoCapacity",
                new List<Argument>(0),
                null);
            return this;
        }

        public VehicleBuilder Consumables()
        {
            IncludeField(
                "consumables",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<VehiclePilotsConnectionBuilder>, VehicleBuilder> PilotConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("pilotConnection");
            return __ =>
            {
                var _ = new VehiclePilotsConnectionBuilder();
                __(_);
                IncludeField(
                    "pilotConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<VehicleFilmsConnectionBuilder>, VehicleBuilder> FilmConnection(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("filmConnection");
            return __ =>
            {
                var _ = new VehicleFilmsConnectionBuilder();
                __(_);
                IncludeField(
                    "filmConnection",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public VehicleBuilder Created()
        {
            IncludeField(
                "created",
                new List<Argument>(0),
                null);
            return this;
        }

        public VehicleBuilder Edited()
        {
            IncludeField(
                "edited",
                new List<Argument>(0),
                null);
            return this;
        }

        public VehicleBuilder Id()
        {
            IncludeField(
                "id",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class VehiclePilotsConnectionBuilder : TypeBase
    {
        public VehiclePilotsConnectionBuilder() : base("VehiclePilotsConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, VehiclePilotsConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<VehiclePilotsEdgeBuilder>, VehiclePilotsConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new VehiclePilotsEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public VehiclePilotsConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<PersonBuilder>, VehiclePilotsConnectionBuilder> Pilots()
        {
            IncludingField("pilots");
            return __ =>
            {
                var _ = new PersonBuilder();
                __(_);
                IncludeField(
                    "pilots",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class VehiclePilotsEdgeBuilder : TypeBase
    {
        public VehiclePilotsEdgeBuilder() : base("VehiclePilotsEdge")
        {
        }


        public Func<Action<PersonBuilder>, VehiclePilotsEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new PersonBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public VehiclePilotsEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class VehicleFilmsConnectionBuilder : TypeBase
    {
        public VehicleFilmsConnectionBuilder() : base("VehicleFilmsConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, VehicleFilmsConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<VehicleFilmsEdgeBuilder>, VehicleFilmsConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new VehicleFilmsEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public VehicleFilmsConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<FilmBuilder>, VehicleFilmsConnectionBuilder> Films()
        {
            IncludingField("films");
            return __ =>
            {
                var _ = new FilmBuilder();
                __(_);
                IncludeField(
                    "films",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class VehicleFilmsEdgeBuilder : TypeBase
    {
        public VehicleFilmsEdgeBuilder() : base("VehicleFilmsEdge")
        {
        }


        public Func<Action<FilmBuilder>, VehicleFilmsEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new FilmBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public VehicleFilmsEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class PlanetFilmsConnectionBuilder : TypeBase
    {
        public PlanetFilmsConnectionBuilder() : base("PlanetFilmsConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, PlanetFilmsConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<PlanetFilmsEdgeBuilder>, PlanetFilmsConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new PlanetFilmsEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public PlanetFilmsConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<FilmBuilder>, PlanetFilmsConnectionBuilder> Films()
        {
            IncludingField("films");
            return __ =>
            {
                var _ = new FilmBuilder();
                __(_);
                IncludeField(
                    "films",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class PlanetFilmsEdgeBuilder : TypeBase
    {
        public PlanetFilmsEdgeBuilder() : base("PlanetFilmsEdge")
        {
        }


        public Func<Action<FilmBuilder>, PlanetFilmsEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new FilmBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public PlanetFilmsEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class SpeciesPeopleConnectionBuilder : TypeBase
    {
        public SpeciesPeopleConnectionBuilder() : base("SpeciesPeopleConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, SpeciesPeopleConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<SpeciesPeopleEdgeBuilder>, SpeciesPeopleConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new SpeciesPeopleEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public SpeciesPeopleConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<PersonBuilder>, SpeciesPeopleConnectionBuilder> People()
        {
            IncludingField("people");
            return __ =>
            {
                var _ = new PersonBuilder();
                __(_);
                IncludeField(
                    "people",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class SpeciesPeopleEdgeBuilder : TypeBase
    {
        public SpeciesPeopleEdgeBuilder() : base("SpeciesPeopleEdge")
        {
        }


        public Func<Action<PersonBuilder>, SpeciesPeopleEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new PersonBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public SpeciesPeopleEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class SpeciesFilmsConnectionBuilder : TypeBase
    {
        public SpeciesFilmsConnectionBuilder() : base("SpeciesFilmsConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, SpeciesFilmsConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<SpeciesFilmsEdgeBuilder>, SpeciesFilmsConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new SpeciesFilmsEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public SpeciesFilmsConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<FilmBuilder>, SpeciesFilmsConnectionBuilder> Films()
        {
            IncludingField("films");
            return __ =>
            {
                var _ = new FilmBuilder();
                __(_);
                IncludeField(
                    "films",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class SpeciesFilmsEdgeBuilder : TypeBase
    {
        public SpeciesFilmsEdgeBuilder() : base("SpeciesFilmsEdge")
        {
        }


        public Func<Action<FilmBuilder>, SpeciesFilmsEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new FilmBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public SpeciesFilmsEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class FilmStarshipsConnectionBuilder : TypeBase
    {
        public FilmStarshipsConnectionBuilder() : base("FilmStarshipsConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, FilmStarshipsConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<FilmStarshipsEdgeBuilder>, FilmStarshipsConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new FilmStarshipsEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public FilmStarshipsConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<StarshipBuilder>, FilmStarshipsConnectionBuilder> Starships()
        {
            IncludingField("starships");
            return __ =>
            {
                var _ = new StarshipBuilder();
                __(_);
                IncludeField(
                    "starships",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class FilmStarshipsEdgeBuilder : TypeBase
    {
        public FilmStarshipsEdgeBuilder() : base("FilmStarshipsEdge")
        {
        }


        public Func<Action<StarshipBuilder>, FilmStarshipsEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new StarshipBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public FilmStarshipsEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class FilmVehiclesConnectionBuilder : TypeBase
    {
        public FilmVehiclesConnectionBuilder() : base("FilmVehiclesConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, FilmVehiclesConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<FilmVehiclesEdgeBuilder>, FilmVehiclesConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new FilmVehiclesEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public FilmVehiclesConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<VehicleBuilder>, FilmVehiclesConnectionBuilder> Vehicles()
        {
            IncludingField("vehicles");
            return __ =>
            {
                var _ = new VehicleBuilder();
                __(_);
                IncludeField(
                    "vehicles",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class FilmVehiclesEdgeBuilder : TypeBase
    {
        public FilmVehiclesEdgeBuilder() : base("FilmVehiclesEdge")
        {
        }


        public Func<Action<VehicleBuilder>, FilmVehiclesEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new VehicleBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public FilmVehiclesEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class FilmCharactersConnectionBuilder : TypeBase
    {
        public FilmCharactersConnectionBuilder() : base("FilmCharactersConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, FilmCharactersConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<FilmCharactersEdgeBuilder>, FilmCharactersConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new FilmCharactersEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public FilmCharactersConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<PersonBuilder>, FilmCharactersConnectionBuilder> Characters()
        {
            IncludingField("characters");
            return __ =>
            {
                var _ = new PersonBuilder();
                __(_);
                IncludeField(
                    "characters",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class FilmCharactersEdgeBuilder : TypeBase
    {
        public FilmCharactersEdgeBuilder() : base("FilmCharactersEdge")
        {
        }


        public Func<Action<PersonBuilder>, FilmCharactersEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new PersonBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public FilmCharactersEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class FilmPlanetsConnectionBuilder : TypeBase
    {
        public FilmPlanetsConnectionBuilder() : base("FilmPlanetsConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, FilmPlanetsConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<FilmPlanetsEdgeBuilder>, FilmPlanetsConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new FilmPlanetsEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public FilmPlanetsConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<PlanetBuilder>, FilmPlanetsConnectionBuilder> Planets()
        {
            IncludingField("planets");
            return __ =>
            {
                var _ = new PlanetBuilder();
                __(_);
                IncludeField(
                    "planets",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class FilmPlanetsEdgeBuilder : TypeBase
    {
        public FilmPlanetsEdgeBuilder() : base("FilmPlanetsEdge")
        {
        }


        public Func<Action<PlanetBuilder>, FilmPlanetsEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new PlanetBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public FilmPlanetsEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class PeopleConnectionBuilder : TypeBase
    {
        public PeopleConnectionBuilder() : base("PeopleConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, PeopleConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<PeopleEdgeBuilder>, PeopleConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new PeopleEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public PeopleConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<PersonBuilder>, PeopleConnectionBuilder> People()
        {
            IncludingField("people");
            return __ =>
            {
                var _ = new PersonBuilder();
                __(_);
                IncludeField(
                    "people",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class PeopleEdgeBuilder : TypeBase
    {
        public PeopleEdgeBuilder() : base("PeopleEdge")
        {
        }


        public Func<Action<PersonBuilder>, PeopleEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new PersonBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public PeopleEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class PlanetsConnectionBuilder : TypeBase
    {
        public PlanetsConnectionBuilder() : base("PlanetsConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, PlanetsConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<PlanetsEdgeBuilder>, PlanetsConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new PlanetsEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public PlanetsConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<PlanetBuilder>, PlanetsConnectionBuilder> Planets()
        {
            IncludingField("planets");
            return __ =>
            {
                var _ = new PlanetBuilder();
                __(_);
                IncludeField(
                    "planets",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class PlanetsEdgeBuilder : TypeBase
    {
        public PlanetsEdgeBuilder() : base("PlanetsEdge")
        {
        }


        public Func<Action<PlanetBuilder>, PlanetsEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new PlanetBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public PlanetsEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class SpeciesConnectionBuilder : TypeBase
    {
        public SpeciesConnectionBuilder() : base("SpeciesConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, SpeciesConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<SpeciesEdgeBuilder>, SpeciesConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new SpeciesEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public SpeciesConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<SpeciesBuilder>, SpeciesConnectionBuilder> Species()
        {
            IncludingField("species");
            return __ =>
            {
                var _ = new SpeciesBuilder();
                __(_);
                IncludeField(
                    "species",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class SpeciesEdgeBuilder : TypeBase
    {
        public SpeciesEdgeBuilder() : base("SpeciesEdge")
        {
        }


        public Func<Action<SpeciesBuilder>, SpeciesEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new SpeciesBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public SpeciesEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class StarshipsConnectionBuilder : TypeBase
    {
        public StarshipsConnectionBuilder() : base("StarshipsConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, StarshipsConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<StarshipsEdgeBuilder>, StarshipsConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new StarshipsEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public StarshipsConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<StarshipBuilder>, StarshipsConnectionBuilder> Starships()
        {
            IncludingField("starships");
            return __ =>
            {
                var _ = new StarshipBuilder();
                __(_);
                IncludeField(
                    "starships",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class StarshipsEdgeBuilder : TypeBase
    {
        public StarshipsEdgeBuilder() : base("StarshipsEdge")
        {
        }


        public Func<Action<StarshipBuilder>, StarshipsEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new StarshipBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public StarshipsEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class VehiclesConnectionBuilder : TypeBase
    {
        public VehiclesConnectionBuilder() : base("VehiclesConnection")
        {
        }


        public Func<Action<PageInfoBuilder>, VehiclesConnectionBuilder> PageInfo()
        {
            IncludingField("pageInfo");
            return __ =>
            {
                var _ = new PageInfoBuilder();
                __(_);
                IncludeField(
                    "pageInfo",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public Func<Action<VehiclesEdgeBuilder>, VehiclesConnectionBuilder> Edges()
        {
            IncludingField("edges");
            return __ =>
            {
                var _ = new VehiclesEdgeBuilder();
                __(_);
                IncludeField(
                    "edges",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public VehiclesConnectionBuilder TotalCount()
        {
            IncludeField(
                "totalCount",
                new List<Argument>(0),
                null);
            return this;
        }

        public Func<Action<VehicleBuilder>, VehiclesConnectionBuilder> Vehicles()
        {
            IncludingField("vehicles");
            return __ =>
            {
                var _ = new VehicleBuilder();
                __(_);
                IncludeField(
                    "vehicles",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }
    }

    public class VehiclesEdgeBuilder : TypeBase
    {
        public VehiclesEdgeBuilder() : base("VehiclesEdge")
        {
        }


        public Func<Action<VehicleBuilder>, VehiclesEdgeBuilder> Node()
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new VehicleBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>(0),
                    _);
                return this;
            };
        }

        public VehiclesEdgeBuilder Cursor()
        {
            IncludeField(
                "cursor",
                new List<Argument>(0),
                null);
            return this;
        }
    }

    public class RootBuilder : TypeBase
    {
        public RootBuilder() : base("Root")
        {
        }


        public Func<Action<FilmsConnectionBuilder>, RootBuilder> AllFilms(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("allFilms");
            return __ =>
            {
                var _ = new FilmsConnectionBuilder();
                __(_);
                IncludeField(
                    "allFilms",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<FilmBuilder>, RootBuilder> Film(
            string id = null,
            string filmID = null)
        {
            IncludingField("film");
            return __ =>
            {
                var _ = new FilmBuilder();
                __(_);
                IncludeField(
                    "film",
                    new List<Argument>
                    {
                        new Argument("id", "ID", id),
                        new Argument("filmID", "ID", filmID),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<PeopleConnectionBuilder>, RootBuilder> AllPeople(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("allPeople");
            return __ =>
            {
                var _ = new PeopleConnectionBuilder();
                __(_);
                IncludeField(
                    "allPeople",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<PersonBuilder>, RootBuilder> Person(
            string id = null,
            string personID = null)
        {
            IncludingField("person");
            return __ =>
            {
                var _ = new PersonBuilder();
                __(_);
                IncludeField(
                    "person",
                    new List<Argument>
                    {
                        new Argument("id", "ID", id),
                        new Argument("personID", "ID", personID),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<PlanetsConnectionBuilder>, RootBuilder> AllPlanets(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("allPlanets");
            return __ =>
            {
                var _ = new PlanetsConnectionBuilder();
                __(_);
                IncludeField(
                    "allPlanets",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<PlanetBuilder>, RootBuilder> Planet(
            string id = null,
            string planetID = null)
        {
            IncludingField("planet");
            return __ =>
            {
                var _ = new PlanetBuilder();
                __(_);
                IncludeField(
                    "planet",
                    new List<Argument>
                    {
                        new Argument("id", "ID", id),
                        new Argument("planetID", "ID", planetID),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<SpeciesConnectionBuilder>, RootBuilder> AllSpecies(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("allSpecies");
            return __ =>
            {
                var _ = new SpeciesConnectionBuilder();
                __(_);
                IncludeField(
                    "allSpecies",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<SpeciesBuilder>, RootBuilder> Species(
            string id = null,
            string speciesID = null)
        {
            IncludingField("species");
            return __ =>
            {
                var _ = new SpeciesBuilder();
                __(_);
                IncludeField(
                    "species",
                    new List<Argument>
                    {
                        new Argument("id", "ID", id),
                        new Argument("speciesID", "ID", speciesID),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<StarshipsConnectionBuilder>, RootBuilder> AllStarships(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("allStarships");
            return __ =>
            {
                var _ = new StarshipsConnectionBuilder();
                __(_);
                IncludeField(
                    "allStarships",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<StarshipBuilder>, RootBuilder> Starship(
            string id = null,
            string starshipID = null)
        {
            IncludingField("starship");
            return __ =>
            {
                var _ = new StarshipBuilder();
                __(_);
                IncludeField(
                    "starship",
                    new List<Argument>
                    {
                        new Argument("id", "ID", id),
                        new Argument("starshipID", "ID", starshipID),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<VehiclesConnectionBuilder>, RootBuilder> AllVehicles(
            string after = null,
            int? first = null,
            string before = null,
            int? last = null)
        {
            IncludingField("allVehicles");
            return __ =>
            {
                var _ = new VehiclesConnectionBuilder();
                __(_);
                IncludeField(
                    "allVehicles",
                    new List<Argument>
                    {
                        new Argument("after", "String", after),
                        new Argument("first", "Int", first),
                        new Argument("before", "String", before),
                        new Argument("last", "Int", last),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<VehicleBuilder>, RootBuilder> Vehicle(
            string id = null,
            string vehicleID = null)
        {
            IncludingField("vehicle");
            return __ =>
            {
                var _ = new VehicleBuilder();
                __(_);
                IncludeField(
                    "vehicle",
                    new List<Argument>
                    {
                        new Argument("id", "ID", id),
                        new Argument("vehicleID", "ID", vehicleID),
                    },
                    _);
                return this;
            };
        }

        public Func<Action<NodeBuilder>, RootBuilder> Node(
            string id)
        {
            IncludingField("node");
            return __ =>
            {
                var _ = new NodeBuilder();
                __(_);
                IncludeField(
                    "node",
                    new List<Argument>
                    {
                        new Argument("id", "ID!", id),
                    },
                    _);
                return this;
            };
        }
    }

    #endregion

    public interface IGraphQlApiClientFactory
    {
        IGraphQlQueryClient<RootDto> CreateQueryClient(Action<RootBuilder> setupAction);
    }


    public class GraphQlApiClientFactory : ClientFactoryBase, IGraphQlApiClientFactory
    {
        public GraphQlApiClientFactory(string url, JsonSerializerSettings jsonSerializerSettings = null)
            : base(url, jsonSerializerSettings)
        {
        }


        public IGraphQlQueryClient<RootDto> CreateQueryClient(Action<RootBuilder> setupAction)
        {
            var type = new RootBuilder();
            setupAction(type);
            return CreateQueryClient<RootDto>(type);
        }
    }
}

namespace Sample.DotNet.Api.Infra
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using GraphQL.Client;
    using GraphQL.Client.Http;
    using GraphQL.Common.Request;
    using GraphQL.Common.Response;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;


    #region Client

    public interface IResponse<out T>
    {
        bool IsCompleted { get; }

        bool IsFailed { get; }

        T Data { get; }

        IReadOnlyList<Error> Errors { get; }
    }

    public interface ISubscription<T> : IDisposable
    {
        event EventHandler<IResponse<T>> Received;

        IResponse<T> LastResponse { get; }
    }

    public class Response<T> : IResponse<T>
    {
        private T _data;


        public bool IsCompleted { get; }

        public bool IsFailed => !IsCompleted;

        public T Data
        {
            get
            {
                if (IsFailed)
                {
                    throw new InvalidOperationException("Can not get data from failed response.");
                }

                return _data;
            }
            protected set => _data = value;
        }

        public IReadOnlyList<Error> Errors { get; }


        private Response(T data)
        {
            _data = data;

            IsCompleted = true;
            Errors = Array.Empty<Error>();
        }

        private Response(IReadOnlyList<Error> errors)
        {
            Errors = errors;

            IsCompleted = false;
        }


        public static Response<T> CreateFrom(GraphQLResponse graphQlResponse)
        {
            if (graphQlResponse == null)
            {
                return null;
            }

            if (graphQlResponse.Errors != null && graphQlResponse.Errors.Length > 0)
            {
                var errors = graphQlResponse.Errors.Select(
                        e => new Error(
                            e.Message,
                            e.Locations?.Select(l => new Error.Location(l.Column, l.Line)).ToList(),
                            e.AdditionalEntries?.ToDictionary(p => p.Key, p => (object)p.Value)))
                    .ToList();

                return new Response<T>(errors);
            }
            else
            {
                var jData = (JToken)graphQlResponse.Data;
                var dto = jData.ToObject<T>();

                return new Response<T>(dto);
            }
        }
    }

    public class Subscription<T> : ISubscription<T>
    {
        private readonly IGraphQLSubscriptionResult _graphQlSubscriptionResult;


        public event EventHandler<IResponse<T>> Received;


        public IResponse<T> LastResponse { get; }


        public Subscription(IGraphQLSubscriptionResult graphQlSubscriptionResult)
        {
            _graphQlSubscriptionResult = graphQlSubscriptionResult;
            _graphQlSubscriptionResult.OnReceive += r => Received?.Invoke(this, Response<T>.CreateFrom(r));
            LastResponse = Response<T>.CreateFrom(graphQlSubscriptionResult.LastResponse);
        }


        public void Dispose()
        {
            _graphQlSubscriptionResult?.Dispose();
        }
    }

    public class Error
    {
        public string Message { get; }

        public IReadOnlyList<Location> Locations { get; set; }

        public IReadOnlyDictionary<string, object> AdditionalEntries { get; set; }


        public Error(
            string message,
            IReadOnlyList<Location> locations,
            IReadOnlyDictionary<string, object> additionalEntries)
        {
            Message = message;
            Locations = locations;
            AdditionalEntries = additionalEntries;
        }



        public class Location
        {
            public uint Column { get; }

            public uint Line { get; }


            public Location(uint column, uint line)
            {
                Column = column;
                Line = line;
            }
        }
    }

    public interface IGraphQlQueryClient : IDisposable
    {
        Task<IResponse<TDto>> SendAsync<TDto>(CancellationToken cancellationToken = default);
    }

    public interface IGraphQlQueryClient<TDto> : IGraphQlQueryClient
    {
        Task<IResponse<TDto>> SendAsync(CancellationToken cancellationToken = default);
    }

    public interface IGraphQlMutationClient : IDisposable
    {
        Task<IResponse<TDto>> SendAsync<TDto>(CancellationToken cancellationToken = default);
    }

    public interface IGraphQlMutationClient<TDto> : IGraphQlMutationClient
    {
        Task<IResponse<TDto>> SendAsync(CancellationToken cancellationToken = default);
    }

    public interface IGraphQlSubscriptionClient : IDisposable
    {
        Task<ISubscription<TDto>> SendAsync<TDto>(CancellationToken cancellationToken = default);
    }

    public interface IGraphQlSubscriptionClient<TDto> : IGraphQlSubscriptionClient
    {
        Task<ISubscription<TDto>> SendAsync(CancellationToken cancellationToken = default);
    }

    public abstract class GraphQlClientBase : IDisposable
    {
        private static readonly JsonSerializerSettings DefaultJsonSerializerSettings;


        protected GraphQLHttpClient Client { get; }

        protected GraphQLRequest Request { get; }


        static GraphQlClientBase()
        {
            DefaultJsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };
            DefaultJsonSerializerSettings.Converters.Add(new StringEnumConverter());
        }


        protected GraphQlClientBase(
            string url,
            string query,
            Dictionary<string, object> variables,
            JsonSerializerSettings jsonSerializerSettings = null)
        {
            Client = new GraphQLHttpClient(new GraphQLHttpClientOptions
            {
                EndPoint = new Uri(url),
                JsonSerializerSettings = jsonSerializerSettings ?? DefaultJsonSerializerSettings,
            });
            Request = new GraphQLRequest
            {
                Query = query,
                Variables = variables,
            };
        }


        public void Dispose()
        {
            Client.Dispose();
        }
    }

    public class GraphQlQueryClient<TDto> : GraphQlClientBase, IGraphQlQueryClient<TDto>
    {
        public GraphQlQueryClient(
            string url,
            string query,
            Dictionary<string, object> variables,
            JsonSerializerSettings jsonSerializerSettings = null)
            : base(url, query, variables, jsonSerializerSettings)
        {
        }


        public Task<IResponse<TDto>> SendAsync(CancellationToken cancellationToken)
        {
            return SendAsync<TDto>(cancellationToken);
        }

        public async Task<IResponse<T>> SendAsync<T>(CancellationToken cancellationToken)
        {
            var graphQlResponse = await Client.SendQueryAsync(Request, cancellationToken);
            var response = Response<T>.CreateFrom(graphQlResponse);

            return response;
        }
    }

    public class GraphQlMutationClient<TDto> : GraphQlClientBase, IGraphQlMutationClient<TDto>
    {
        public GraphQlMutationClient(
            string url,
            string query,
            Dictionary<string, object> variables,
            JsonSerializerSettings jsonSerializerSettings = null)
            : base(url, query, variables, jsonSerializerSettings)
        {
        }


        public Task<IResponse<TDto>> SendAsync(CancellationToken cancellationToken)
        {
            return SendAsync<TDto>(cancellationToken);
        }

        public async Task<IResponse<T>> SendAsync<T>(CancellationToken cancellationToken)
        {
            var graphQlResponse = await Client.SendMutationAsync(Request, cancellationToken);
            var response = Response<T>.CreateFrom(graphQlResponse);

            return response;
        }
    }

    public class GraphQlSubscriptionClient<TDto> : GraphQlClientBase, IGraphQlSubscriptionClient<TDto>
    {
        public GraphQlSubscriptionClient(
            string url,
            string query,
            Dictionary<string, object> variables,
            JsonSerializerSettings jsonSerializerSettings = null)
            : base(url, query, variables, jsonSerializerSettings)
        {
        }

        public Task<ISubscription<TDto>> SendAsync(CancellationToken cancellationToken)
        {
            return SendAsync<TDto>(cancellationToken);
        }

        public async Task<ISubscription<T>> SendAsync<T>(CancellationToken cancellationToken)
        {
            var graphQlSubscriptionResult = await Client.SendSubscribeAsync(Request, cancellationToken);
            var subscription = new Subscription<T>(graphQlSubscriptionResult);

            return subscription;
        }
    }

    public abstract class ClientFactoryBase
    {
        private readonly string _url;
        private readonly JsonSerializerSettings _jsonSerializerSettings;


        protected ClientFactoryBase(string url, JsonSerializerSettings jsonSerializerSettings = null)
        {
            _url = url;
            _jsonSerializerSettings = jsonSerializerSettings;
        }


        protected IGraphQlQueryClient<TDto> CreateQueryClient<TDto>(TypeBase type)
        {
            var (requestQuery, variables) = PrepareRequestData("query", type);
            return new GraphQlQueryClient<TDto>(_url, requestQuery, variables, _jsonSerializerSettings);
        }

        protected IGraphQlMutationClient<TDto> CreateMutationClient<TDto>(TypeBase type)
        {
            var (requestQuery, variables) = PrepareRequestData("mutation", type);
            return new GraphQlMutationClient<TDto>(_url, requestQuery, variables, _jsonSerializerSettings);
        }

        protected IGraphQlSubscriptionClient<TDto> CreateSubscriptionClient<TDto>(TypeBase type)
        {
            var (requestQuery, variables) = PrepareRequestData("subscription", type);
            return new GraphQlSubscriptionClient<TDto>(_url, requestQuery, variables, _jsonSerializerSettings);
        }


        private static (string requestQuery, Dictionary<string, object> variables) PrepareRequestData(string requestType, TypeBase type)
        {
            ((ITypeValidator)type).ThrowIfNotValid();

            var arguments = ((IArgumentsProvider)type).GetArguments().ToList();
            var requestQuery = BuildQuery(requestType, type, arguments);
            var variables = arguments.ToDictionary(a => a.Id, a => a.Value);

            return (requestQuery, variables);
        }

        private static string BuildQuery(string requestType, IRequestBuilder requestBuilder, IReadOnlyCollection<Argument> arguments)
        {
            var stringBuilder = new StringBuilder(requestType);

            if (arguments.Count > 0)
            {
                stringBuilder.Append("(");
                foreach (var argument in arguments)
                {
                    stringBuilder.Append($"${argument.Id}:{argument.Type},");
                }
                stringBuilder.Length--;
                stringBuilder.Append(")");
            }

            stringBuilder.Append("{");
            requestBuilder.AppendRequest(stringBuilder);
            stringBuilder.Append("}");

            return stringBuilder.ToString();
        }
    }

    #endregion

    #region Providers

    public interface IArgumentsProvider
    {
        IEnumerable<Argument> GetArguments();
    }

    public interface INameProvider
    {
        string Name { get; }
    }

    public interface IRequestBuilder
    {
        void AppendRequest(StringBuilder builder);
    }

    public interface ITypeValidator
    {
        void ThrowIfNotValid();
    }

    #endregion

    #region Fields

    public sealed class Argument
    {
        public string Id { get; }
        public string Name { get; }
        public string Type { get; }
        public object Value { get; }


        public Argument(string name, string type, object value)
        {
            Name = name;
            Type = type;
            Value = value;

            Id = $"{Name}_{Guid.NewGuid():N}";
        }
    }

    public class Field : FieldBase
    {
        private readonly List<Argument> _arguments;


        public Field(string key, List<Argument> arguments, TypeBase type)
            : base(key, type)
        {
            _arguments = arguments;
        }


        protected sealed override void AppendArguments(StringBuilder builder)
        {
            if (_arguments.Count > 0)
            {
                builder.Append("(");
                foreach (var argument in _arguments)
                {
                    builder.Append($"{argument.Name}:${argument.Id},");
                }
                builder.Length--;
                builder.Append(")");
            }
        }

        protected override IEnumerable<Argument> GetArguments()
        {
            foreach (var argument in base.GetArguments())
            {
                yield return argument;
            }

            foreach (var argument in _arguments)
            {
                yield return argument;
            }
        }
    }

    public class OnTypeField : FieldBase
    {
        public OnTypeField(TypeBase type)
            : base($"... on {((INameProvider)type).Name}", type)
        {
        }

        protected override void AppendArguments(StringBuilder builder)
        {
        }
    }

    public abstract class FieldBase : IRequestBuilder, IArgumentsProvider, ITypeValidator
    {
        private readonly string _key;


        protected TypeBase Type { get; }


        protected FieldBase(string key, TypeBase type)
        {
            _key = key;
            Type = type;
        }


        void IRequestBuilder.AppendRequest(StringBuilder builder)
        {
            builder.Append(_key);

            AppendArguments(builder);

            if (Type is IRequestBuilder typeRequestBuilder)
            {
                builder.Append("{");
                typeRequestBuilder.AppendRequest(builder);
                builder.Append("}");
            }
        }

        IEnumerable<Argument> IArgumentsProvider.GetArguments()
        {
            return GetArguments();
        }

        void ITypeValidator.ThrowIfNotValid()
        {
            ((ITypeValidator)Type)?.ThrowIfNotValid();
        }


        protected abstract void AppendArguments(StringBuilder builder);

        protected virtual IEnumerable<Argument> GetArguments()
        {
            return Type != null
                ? ((IArgumentsProvider)Type).GetArguments()
                : Enumerable.Empty<Argument>();
        }
    }

    #endregion

    #region Types

    public abstract class TypeBase : IRequestBuilder, IArgumentsProvider, INameProvider, ITypeValidator
    {
        private readonly string _name;
        private readonly List<FieldBase> _fields;
        private readonly List<string> _includingFieldNames;


        string INameProvider.Name => _name;


        protected TypeBase(string name)
        {
            _name = name;
            _fields = new List<FieldBase>();
            _includingFieldNames = new List<string>();
        }


        void IRequestBuilder.AppendRequest(StringBuilder builder)
        {
            foreach (var field in _fields)
            {
                var requestBuilder = (IRequestBuilder)field;
                if (requestBuilder != null)
                {
                    requestBuilder.AppendRequest(builder);
                    builder.Append(" ");
                }
            }
        }

        IEnumerable<Argument> IArgumentsProvider.GetArguments()
        {
            foreach (var field in _fields)
            {
                var argumentsProvider = (IArgumentsProvider)field;
                if (argumentsProvider != null)
                {
                    foreach (var argument in argumentsProvider.GetArguments())
                    {
                        yield return argument;
                    }
                }
            }
        }

        void ITypeValidator.ThrowIfNotValid()
        {
            if (_includingFieldNames.Count > 0)
            {
                throw new InvalidOperationException($"Following fields from '{GetType().Name}' not setup: {string.Join(", ", _includingFieldNames)}");
            }

            foreach (var field in _fields)
            {
                if (field is ITypeValidator typeValidator)
                {
                    typeValidator.ThrowIfNotValid();
                }
            }
        }


        protected void IncludingField(string fieldName)
        {
            _includingFieldNames.Add(fieldName);
        }

        protected void IncludeField(string fieldName, List<Argument> arguments, TypeBase type)
        {
            _includingFieldNames.Remove(fieldName);
            _fields.Add(new Field(fieldName, arguments, type));
        }

        protected void IncludeOnTypeField(TypeBase type)
        {
            _fields.Add(new OnTypeField(type));
        }
    }

    #endregion

}

