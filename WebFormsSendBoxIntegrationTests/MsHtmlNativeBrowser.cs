using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core.Native.InternetExplorer;
using System.Windows.Forms;
using mshtml;
using WatiN.Core.Native;

namespace WebFormsSendBoxIntegrationTests
{
    public class MsHtmlNativeBrowser : INativeBrowser
    {
        private IEDocument _ieDocument;

        public void NavigateTo(Uri url)
        {
            var htmlDoc = new HTMLDocumentClass();
            var ips = (IPersistStreamInit)htmlDoc;
            ips.InitNew();

            var htmlDoc2 = htmlDoc.createDocumentFromUrl(url.AbsoluteUri, "null");

            while (htmlDoc2.readyState != "complete")
            {
                //This is also a important part, without this DoEvents() appz hangs on to the “loading”
                Application.DoEvents();
            }
            _ieDocument = new IEDocument(htmlDoc2);
        }

        public INativeDocument NativeDocument
        {
            get { return _ieDocument; }
        }

        public void NavigateToNoWait(Uri url)
        {
            throw new NotImplementedException();
        }

        public bool GoBack()
        {
            throw new NotImplementedException();
        }

        public bool GoForward()
        {
            throw new NotImplementedException();
        }

        public void Reopen()
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }

        public IntPtr hWnd
        {
            get { throw new NotImplementedException(); }
        }
    }
}
