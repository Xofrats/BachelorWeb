using BachelorWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace BachelorWeb.Models
{
    public class ChartMaker
    {
        private Learn_BasicEntities db = new Learn_BasicEntities();
        public ChartMaker()
        {
            
        }

        public void MakeChartData(int iD)
        {
            MakeBarChartScore(iD);
            Chart_hints_Person(iD);

        }

        public void MakeBarChartScore(int iD)
        {
            List<string> navne = new List<string>();
            List<int> scorer = new List<int>();
            List<int> ids = new List<int>();

            var ChartData = (from e in db.Elev
                             join d in db.Data on e.ID equals d.ID_Elev
                             where d.ID_Opgave == iD
                             orderby d.Score descending
                             select new
                             {
                                 e.ID,
                                 e.Fornavn,
                                 d.Score
                             }).ToArray();

            foreach (var d in ChartData)
            {
                if (!(ids.Contains(d.ID)))
                {
                    navne.Add(d.Fornavn);
                    scorer.Add(d.Score);
                    ids.Add(d.ID);
                }
            }

            HttpContext.Current.Session["chartDataX"] = navne;
            HttpContext.Current.Session["chartDataY"] = scorer;
        }

        public void Chart_hints_Person(int iD)
        {
            List<string> navne = new List<string>();
            List<int> hints = new List<int>();
            List<int> ids = new List<int>();

            var ChartData = (from e in db.Elev
                             join d in db.Data on e.ID equals d.ID_Elev
                             where d.ID_Opgave == iD
                             orderby d.Score descending
                             select new
                             {
                                 e.ID,
                                 e.Fornavn,
                                 d.Hints
                             }).ToArray();

            foreach (var d in ChartData)
            {
                if (!(ids.Contains(d.ID)))
                {
                    
                    navne.Add(d.Fornavn);
                    hints.Add(d.Hints.GetValueOrDefault(0));
                    ids.Add(d.ID);
                }
            }

            HttpContext.Current.Session["chart_navne"] = navne;
            HttpContext.Current.Session["chart_hints"] = hints;

        }
    }
}