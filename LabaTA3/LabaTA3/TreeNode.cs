using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaTA3
{
    class TreeNode<T> where T:IComparable
    {
        public T data;
        public TreeNode<T> left;
        public TreeNode<T> right;
        public TreeNode<T> parent;
        public TreeNode(T data)
        {
            this.data = data;
        }
        public T Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        } 
        public TreeNode<T> Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }
        public TreeNode<T> Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }
        public TreeNode<T> Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }
    }
}
