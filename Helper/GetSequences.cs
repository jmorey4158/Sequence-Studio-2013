using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using SequenceStudio.Internal.Classes;
using System.Xml.Serialization;
using SequenceStudio;


namespace SequenceStudio
{
    public static class GetSequences
    {

        public static TSeq GetTSeqFromNcbi(string uri)
        {
            TSeq seq = new TSeq();

            WebRequest request = WebRequest.Create(uri);

            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Get the stream containing content returned by the server.

            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);

            String seqStr = reader.ReadToEnd();
            XmlReaderSettings xrs = new XmlReaderSettings()
            {
                DtdProcessing = DtdProcessing.Ignore
            };


            using (XmlReader xreader = XmlReader.Create(new StringReader(seqStr), xrs))
            {

                    // Parse the file and display each of the nodes.
                    while (xreader.Read())
                    {
                        switch (xreader.Name)
                        {
                            case "TSeq_seqtype":
                                seq.TSeq_seqtype = xreader.GetAttribute("value");
                                break;
                            case "TSeq_gi":
                                seq.TSeq_gi = xreader.ReadElementContentAsString();
                                break;
                            case "TSeq_accver":
                                seq.TSeq_accver = xreader.ReadElementContentAsString();
                                break;
                            case "TSeq_taxid":
                                seq.TSeq_taxid = xreader.ReadElementContentAsString();
                                break;
                            case "TSeq_orgname":
                                seq.TSeq_orgname = xreader.ReadElementContentAsString();
                                break;
                            case "TSeq_defline":
                                seq.TSeq_defline = xreader.ReadElementContentAsString();
                                break;
                            case "TSeq_length":
                                seq.TSeq_length = xreader.ReadElementContentAsString();
                                break;
                            case "TSeq_sequence":
                                seq.TSeq_sequence = xreader.ReadElementContentAsString();
                                break;
                        }
                    }
            }


            return seq;
        }


        public static XmlDocument GetSequenceXmlFromNCBI(string uri)
        {
            XmlDocument xdoc = new XmlDocument();

            WebRequest request = WebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            xdoc.LoadXml(reader.ReadToEnd());

            reader.Close();
            dataStream.Close();
            response.Close();

            return xdoc;
        }


        public static XmlDocument GetIDsFromNCBI(string uri)
        {
            XmlDocument xdoc = new XmlDocument();

            WebRequest request = WebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            xdoc.LoadXml(reader.ReadToEnd());

            reader.Close();
            dataStream.Close();
            response.Close();

            return xdoc;
        }

        public static SequenceBase TranslateTSeqToSequenceClass(TSeq seq)
        {
            return new SequenceBase(Guid.NewGuid(),
                seq.TSeq_taxid, seq.TSeq_accver, seq.TSeq_orgname, seq.TSeq_gi, seq.TSeq_defline, seq.TSeq_sequence);
        }


        public static SequenceBase GetSequenceBaseFromNcbi(string uri)
        {

            TSeq seq = GetTSeqFromNcbi(uri);

            return new SequenceBase(Guid.NewGuid(),
                seq.TSeq_taxid, seq.TSeq_accver, seq.TSeq_orgname, seq.TSeq_gi, seq.TSeq_defline, seq.TSeq_sequence);
        }



        public static TSeq GetSequenceFromXML(string path)
        {
            TSeq seq = new TSeq();
            XmlSerializer serializer = new XmlSerializer(typeof(TSeq));
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlReaderSettings xrs = new XmlReaderSettings()
            {
                DtdProcessing = DtdProcessing.Ignore
            };
            XmlReader reader = XmlReader.Create(fs, xrs);
            seq = (TSeq)serializer.Deserialize(reader);
            fs.Close();
            reader.Close();
            return seq;
        } //NOT WORKING





    }
}
