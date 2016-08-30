//This file is part of Sequence Studio 2011, an application by Revealed Design, LLC. 
//Copyright© 2011 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

using SequenceStudio.Internal;

namespace SequenceStudio
{
    public static class NcbiMethods
    {

        public static List<DNA> SequenceList(String ncbiDatabase, String query, Int32 retmax, ref List<String> failures)
        {
            Console.WriteLine("Starting method: SequenceList");

            //Get list of IDs from search result
            List<String> list = IdList(ncbiDatabase, query, retmax);
            List<DNA> dList = new List<DNA>();

            if (list.Count == 0)
            {
                SequenceException se = new SequenceException();
                se.ContextMessage = "The input list has no members.";
                throw se;
            }

            eFetchSeq.eFetchResult res = new eFetchSeq.eFetchResult();

            foreach (String s in list)
            {
                eFetchSeq.eFetchRequest req = Request(s, ncbiDatabase);

                try
                {
                    res = Results(req);
                    if (res != null)
                    {
                        Console.WriteLine("DnaFromResults");
                        DnaFromResults(res, ref dList);
                    }                    
                }
                catch (System.ServiceModel.CommunicationException ce)
                {
                    Console.WriteLine("CommunicationException");
                    failures.Add(req.id);
                }
            }

            
            return dList;
        }


        public static List<String> IdList(String ncbiDatabase, String query, Int32 retmax)
        {
            List<string> idList = new List<string>();
            retmax = (retmax > 10000) ? 10000 : retmax;
            String max = retmax.ToString();
            
            try
            {
                eUtils.eUtilsServiceSoapClient servSearch = new eUtils.eUtilsServiceSoapClient();
                // call NCBI EGQuery utility        
                eUtils.eSearchRequest req = new eUtils.eSearchRequest();
                req.db = ncbiDatabase;
                req.RetMax = max;
                req.term = query;
                eUtils.eSearchResult res = servSearch.run_eSearch(req);
                // results output        
                for (Int32 index = 0; index < res.IdList.Count(); index++)
                {
                    idList.Add(res.IdList[index]);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return idList;
        }


        public static eFetchSeq.eFetchRequest Request(List<string> list, String ncbiDatabase)
        {
            if (list.Count == 0)
            {
                SequenceException se = new SequenceException();
                se.ContextMessage = "The input list has no members.";
                throw se;
            }


            StringBuilder sb = new StringBuilder();
            foreach (string s in list)
            {
                sb.Append(s + ",");
            }
            String idList = sb.ToString();
            idList = idList.Substring(0, idList.Length - 1);

            // Create Request ovbject
            eFetchSeq.eFetchRequest req = new eFetchSeq.eFetchRequest();
            req.db = ncbiDatabase;
            req.id = idList;
            req.complexity = "3";

            return req;
        }

        public static eFetchSeq.eFetchRequest Request(String id, String ncbiDatabase)
        {
            if (String.IsNullOrEmpty(id))
            {
                SequenceException se = new SequenceException();
                se.ContextMessage = "The input list has no members.";
                throw se;
            }

            eFetchSeq.eFetchRequest req = new eFetchSeq.eFetchRequest();
            req.db = ncbiDatabase;
            req.id = id;
            req.retmax = "1";
            req.complexity = "3";

            return req;
        }



        public static eFetchSeq.eFetchResult Results(eFetchSeq.eFetchRequest req)
        {
            eFetchSeq.eUtilsServiceSoapClient serveFetchSeq = new eFetchSeq.eUtilsServiceSoapClient();
            return serveFetchSeq.run_eFetch(req);
        }


        public static List<DNA> DnaFromResults(eFetchSeq.eFetchResult res, ref List<DNA> dList)
        {

            if (res.GBSet != null)
            {
                for (int index = 0; index < res.GBSet.GBSeq.Count(); index++)
                {
                    try
                    {
                        DNA d = new DNA(Guid.NewGuid(),
                        "",
                        res.GBSet.GBSeq[index].GBSeq_accessionversion,
                        res.GBSet.GBSeq[index].GBSeq_organism,
                        res.GBSet.GBSeq[index].GBSeq_locus,
                        "",
                        res.GBSet.GBSeq[index].GBSeq_sequence);

                        dList.Add(d);
                    }
                    catch (SequenceParameterException pe)
                    {
                        pe.ParameterName = "Sequence";
                        pe.ParameterMessage = res.GBSet.GBSeq[index].GBSeq_sequence;
                    }
                }
            }
            return dList;
        }

    }
}
