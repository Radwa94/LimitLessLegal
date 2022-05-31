using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 
    public class permisions
    {
    public int group_id { get; set; }
    public List<listchekbox> lstchekbox { get; set; }
    }

public class listchekbox
{
    public string page_url { get; set; }
    public string page_title { get; set; }
    public bool is_selected { get; set; }
}
 
