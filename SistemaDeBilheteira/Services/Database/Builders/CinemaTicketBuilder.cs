// using SistemaDeBilheteira.Services.Database.Entities;
// using SistemaDeBilheteira.Services.Database.Entities.Cinema;

// public class CinemaTicketBuilder
// {
//     protected string AppUserId { get; set; } = string.Empty;
//     protected AppUser AppUser { get; set; } = null!;
//     protected int Price { get; set; }
//     protected int SeatNumber { get; set; }
//     protected DateTime Date { get; set; }
//     protected Movie Movie { get; set; } = null!;
//     protected Cinema Cinema { get; set; } = null!;
//     protected Quantity Quantity { get; set; } = null!;
//     protected bool IsReserved { get; set; } = false;

//     public CinemaTicketBuilder WithAppUserId(string appUserId)
//     {
//         AppUserId = appUserId;
//         return this;
//     }

//     public CinemaTicketBuilder WithAppUser(AppUser appUser)
//     {
//         AppUser = appUser;
//         return this;
//     }

//     public CinemaTicketBuilder WithPrice(int price)
//     {
//         Price = price;
//         return this;
//     }

//     public CinemaTicketBuilder WithSeatNumber(int seatNumber)
//     {
//         SeatNumber = seatNumber;
//         return this;
//     }

//     public CinemaTicketBuilder WithDate(DateTime date)
//     {
//         Date = date;
//         return this;
//     }

//     public CinemaTicketBuilder WithMovie(Movie movie)
//     {
//         Movie = movie;
//         return this;
//     }

//     public CinemaTicketBuilder WithCinema(Cinema cinema)
//     {
//         Cinema = cinema;
//         return this;
//     }

//     public CinemaTicketBuilder WithQuantity(Quantity quantity)
//     {
//         Quantity = quantity;
//         return this;
//     }

//     public CinemaTicketBuilder WithIsReserved(bool isReserved)
//     {
//         IsReserved = isReserved;
//         return this;
//     }

//     public CinemaTicket Build()
//     {
//         var built = new CinemaTicket
//         {
//             AppUserId = AppUserId,
//             AppUser = AppUser,
//             Price = Price,
//             SeatNumber = SeatNumber,
//             Date = Date,
//             Movie = Movie,
//             Cinema = Cinema,
//             Quantity = Quantity,
//             IsReserved = IsReserved
//         };
//         return built;
//     }
// }




