using ScouterTool.APIs;
using ScouterTool.Forms;
using ScouterTool.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScouterTool
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private List<clsWayPoint> lstKeyWord = new List<clsWayPoint>();
        private Regex regPoint = new Regex("(?<=EVE系统 > 频道更换为本地：).*");
        private Regex regDateTime = new Regex(@"(?<=\[ ).*(?= \])");

        private void btnLogReader_Click(object sender, EventArgs e)
        {
            frmLogReader newFrm = new frmLogReader();
            newFrm.ShowDialog();

            string strFile = newFrm.SelectedFile;

            if (!File.Exists(strFile))
            {
                MessageBox.Show("文件夹不存在");
            }
            StreamReader sr = new StreamReader(strFile);

            lstKeyWord.Clear();
            while (!sr.EndOfStream)
            {
                string strLine = sr.ReadLine();
                if (regPoint.IsMatch(strLine))
                {
                    clsWayPoint wp = new clsWayPoint();
                    wp.DateTime = regDateTime.Match(strLine).Value;
                    wp.PointName = regPoint.Match(strLine).Value;
                    lstKeyWord.Add(wp);
                }
            }

            ReadWayPointList(lstKeyWord);
        }

        private void ReadWayPointList(List<clsWayPoint> wayPoints)
        {
            TreeNodeCollection tncWayPointRoot = tvWayPoint.Nodes;
            tncWayPointRoot.Clear();

            clsWayPoint wpLast = null;
            foreach (clsWayPoint wp in wayPoints)
            {
                //从星系开始记录
                if (wpLast == null)
                {
                    if (!wp.PointName.StartsWith("J"))
                    {
                        wpLast = wp;
                    }
                    continue;
                }
                //虫洞
                if (wp.PointName.StartsWith("J"))
                {
                    if (!wpLast.PointName.StartsWith("J"))
                    {
                        //洞外→洞内
                        TreeNode tnRoot = SearchTreeNode(tncWayPointRoot, wpLast.PointName);
                        TreeNode tnNow = SearchTreeNode(tncWayPointRoot, wp.PointName);
                        
                        if (tnRoot == null)
                        {
                            //排除回洞
                            tnRoot = new TreeNode(wpLast.PointName);
                            tnRoot.Nodes.Add(wp.PointName);
                            tncWayPointRoot.Add(tnRoot);
                        }
                        else
                        {
                            //排除重复进洞
                        }
                    }
                    else
                    {
                        //洞内→洞内
                        TreeNode tnLast = SearchTreeNode(tncWayPointRoot, wpLast.PointName);
                        TreeNode tnNow = SearchTreeNode(tncWayPointRoot, wp.PointName);
                        if (tnNow == null)
                        {
                            tnLast.Nodes.Add(wp.PointName);
                        }
                    }
                }
                else
                {

                    if (!wpLast.PointName.StartsWith("J"))
                    {
                        //洞外→洞外
                    }
                    else
                    {
                        //洞内→洞外
                        TreeNode tnLast = SearchTreeNode(tncWayPointRoot, wpLast.PointName);
                        TreeNode tnNow = SearchTreeNode(tncWayPointRoot, wp.PointName);
                        if (tnNow == null)
                        {
                            tnLast.Nodes.Add(wp.PointName);
                        }
                        else if(tnNow != null && SearchTreeNode(tnLast.Nodes, wp.PointName) != null)
                        {
                            //排除重复探头记录
                        }
                        else if(tnLast != null && SearchTreeNode(tnNow.Nodes, wpLast.PointName) != null)
                        {
                            //排除原地出洞
                        }
                    }
                }
                wpLast = wp;
            }

            tvWayPoint.ExpandAll();
        }

        private static TreeNode SearchTreeNode(TreeNodeCollection tncRoot, string PointName)
        {
            TreeNode tnResult = null;
            foreach (TreeNode tn in tncRoot)
            {
                if (tn.Text == PointName)
                {
                    tnResult = tn;
                    break;
                }
                else
                {
                    tnResult = SearchTreeNode(tn.Nodes, PointName);
                }
            }
            return tnResult;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //ReadWayPointList(lstKeyWord);
            //CommentWayPoint(tvWayPoint.Nodes);
            List<string> lstString = new List<string>();
            lstString.Add("绯舞之夜");
            lstString.Add("奥塔马");
            lstString.Add("J105000");
            ESIAPIs.SearchBulkToIDs(lstString);
        }

        private void CommentWayPoint(TreeNodeCollection tncWayPoint)
        {
            foreach (TreeNode tn in tncWayPoint)
            {
                string strIDs = ESIAPIs.SearchSystem(tn.Text);

            }
        }

        private void CommentWayPoint()
        {
            TreeNodeCollection tncWayPointRoot = tvWayPoint.Nodes;


        }

        private void tvWayPoint_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }
    }
}
