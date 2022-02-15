using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            // ------------Level 1 ----------------//
            // #1 Women's League
            ViewBag.Level1_1 = _context.Leagues.Where(leg => leg.Name.Contains("Womens' "));

            // #2 Hockey League
            ViewBag.Level1_2 = _context.Leagues.Where(leg => leg.Sport.Contains("Hockey"));

            // #3 NOT Football
            ViewBag.Level1_3 = _context.Leagues.Where(leg => !leg.Sport.Contains("Football"));

            // #4 Conferences not Leagues
            ViewBag.Level1_4 = _context.Leagues.Where(leg => leg.Name.Contains("Conference"));

            //#5 All in the Atlantic Region
            ViewBag.Level1_5 = _context.Leagues.Where(leg => leg.Name.Contains("Atlantic"));

            //#6 Teams in Dallas
            ViewBag.Level1_6 = _context.Teams.Where(tea => tea.Location.Contains("Dallas"));

            //#7 All Teams Named Raptors
            ViewBag.Level1_7 = _context.Teams.Where(tea => tea.TeamName.Contains("Raptors"));

            //#8 Team with city in their location
            ViewBag.Level1_8 = _context.Teams.Where(tea => tea.Location.Contains("City"));

            //#9 Team names that begin's with a "T"
            ViewBag.Level1_9 = _context.Teams.Where(tea => tea.TeamName.StartsWith("T"));

            //#10 Ordered by Location... Alphabetically~
            ViewBag.Level1_10= _context.Teams.OrderBy(tea => tea.Location);

            //#11 Ordered by Location... But Reverse!
            ViewBag.Level1_11 = _context.Teams.OrderByDescending(tea => tea.TeamName);

            //#12 All players with the last name "Cooper"
            ViewBag.Level1_12 = _context.Players.Where(play => play.LastName == "Cooper");

            //#13 All players with the first name Joshua
            ViewBag.Level1_13 = _context.Players.Where(play => play.FirstName == "Joshua");

            //#14 Players with last name "Cooper" BUT no "Joshua"s!
            ViewBag.Level1_14 = _context.Players.Where(play => play.LastName == "Cooper" && play.FirstName != "Joshua");

            //#15 All "Alexander" or "Wyatt"
            ViewBag.Level1_15 = _context.Players.Where(play => play.FirstName == "Alexander" || play.FirstName == "Wyatt")
            .OrderBy(play => play.FirstName);
            
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}