using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace eUtils
{
    public static class NcbiMethods
    {

        public static XmlDocument GetSequenceXml(string db, string term, int retmax, int retstart)
        {
            eUtilsService.eSearchResult res = GetSequenceIDs(db, term, retmax, retstart);
            XmlDocument xdoc = new XmlDocument();
            XmlSerializer xser = new XmlSerializer(typeof(eUtilsService.eSearchResult));
            using (var stream = new MemoryStream())
            {
                xser.Serialize(stream, res);
                xdoc.Load(stream);
            }

            return xdoc;

        }


        public static eUtilsService.eSearchResult GetSequenceIDs(string db, string term, int retmax, int retstart)
        {
            XmlDocument xdoc = new XmlDocument();
            eUtilsService.eSearchResult res = new eUtilsService.eSearchResult();
            eUtilsService.eUtilsServiceSoapClient serv = new eUtilsService.eUtilsServiceSoapClient();

            try
            {

                eUtilsService.eSearchRequest req = new eUtilsService.eSearchRequest();
                req.db = db;
                req.term = term;
                req.RetMax = retmax.ToString();
                req.RetStart = retstart.ToString();

                res = serv.run_eSearch(req);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                serv = null;
            }

            //XmlSerializer xser = new XmlSerializer(typeof(eUtilsService.eSearchResult));

            //using (MemoryStream mstream = new MemoryStream())
            //{
            //    XmlWriter writer = new XmlTextWriter(mstream, Encoding.Unicode);
            //    xser.Serialize(mstream, res);

            //}

            return res;
        }


        public static List<eUtilsService.eSearchResult> FetchRecords(eUtilsService.eSearchResult Ids)
        {
            var ids = new List<eUtilsService.eSearchResult>();

            eFetchSequences.eUtilsServiceSoapClient eFetch = new eFetchSequences.eUtilsServiceSoapClient();
            eFetchSequences.eFetchRequest req = new eFetchSequences.eFetchRequest();
            eFetchSequences.eFetchResult res = new eFetchSequences.eFetchResult();

            try
            {
                res = eFetch.run_eFetch(req);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                eFetch = null;
            }





            return ids;
        }


    }
}
