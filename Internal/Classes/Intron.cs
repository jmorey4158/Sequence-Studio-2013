using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceStudio.Internal.Classes
{

    /// <summary>
    /// Instances of this class represent the 'introns' possible in the given DNA strands on the given Poly.
    /// </summary>
    /// <remarks>If no introns are found the Exception passed in will be populated and returned along with an
    /// empty Dictionary(Int32, Int32). </remarks>
    public class Intron : Dictionary<Int32, Int32>
    {


    }

}
