using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaTA3
{
    class Tree<T> where T:IComparable
    {
        public TreeNode<T> root;
        public int count;
        public Tree()
        {
            root = null;
            count = 0;
        }
        public void Insert(T data)
        {
            if(root == null)
            {
                root = new TreeNode<T>(data);
                count++;
                return;
            }
            else
                InsertRecursion(root, data);
            return;
        }
        public void InsertRecursion(TreeNode<T> currentNode,T data)
        {
            if(currentNode.data.CompareTo(data) > 0)
            {
                if(currentNode.left == null)
                {
                    TreeNode<T> tmpNode = new TreeNode<T>(data);
                    tmpNode.parent = currentNode;
                    currentNode.left = tmpNode;
                    count++;
                    return;
                }
                else
                {
                    InsertRecursion(currentNode.left, data);
                    return;
                }
            }
            if(currentNode.data.CompareTo(data) < 0)
            {
                if(currentNode.right == null)
                {
                    currentNode.right = new TreeNode<T>(data);
                    currentNode.right.parent = currentNode;
                    count++;
                    return;
                }
                else
                {
                    InsertRecursion(currentNode.right, data);
                    return;
                }
            }
        }
        public bool Contains(T data, bool remove) => Contains(ref root, data, remove);

        public bool Contains(ref TreeNode<T> currentNode, T data, bool remove)
        {
            if (currentNode != null)
            {
                if (data.CompareTo(currentNode.data) == 0)
                {
                    if(remove)
                        Remove(ref currentNode);
                    return true;
                }
                else if (currentNode.data.CompareTo(data) > 0)
                {
                    TreeNode<T> tmpNode = currentNode.left;
                    return Contains(ref tmpNode, data, remove);
                }
                else
                {
                    TreeNode<T> tmpNode = currentNode.right;
                    return Contains(ref tmpNode, data, remove);
                } 
            }
            else
            {
                return false;
            }
        }
        public void Remove(ref TreeNode<T> currentNode)
        {
            if (currentNode != null)
            {
                if (currentNode != root)
                {
                    if (currentNode.left == null && currentNode.right == null)
                    {
                        if (currentNode.parent.data.CompareTo(currentNode.data) > 0)
                            currentNode.parent.left = null;
                        else
                            currentNode.parent.right = null;
                        currentNode = null;
                    }
                    else if (currentNode.left == null)
                    {
                        if (currentNode.parent.data.CompareTo(currentNode.data) > 0)
                            currentNode.parent.left = currentNode.right;
                        else
                            currentNode.parent.right = currentNode.right;
                        currentNode = currentNode.right;
                    }
                    else if (currentNode.right == null)
                    {
                        if (currentNode.parent.data.CompareTo(currentNode.data) > 0)
                            currentNode.parent.left = currentNode.left;
                        else
                            currentNode.parent.right = currentNode.left;
                        currentNode = currentNode.left;
                    }
                    else
                    {
                        if (currentNode.parent.data.CompareTo(currentNode.data) > 0)
                            currentNode.parent.left = currentNode.right;
                        else
                            currentNode.parent.right = currentNode.right;
                        List<T> data = new List<T>();
                        getElements(currentNode.left, data);
                        data.Sort();
                        T[] array = data.ToArray();
                        Filling(array);
                    } 
                }
                else
                {
                    if (currentNode.left == null && currentNode.right == null)
                    {
                        currentNode = null;
                    }
                    else if (currentNode.left == null)
                    {
                        currentNode = currentNode.right;
                    }
                    else if (currentNode.right == null)
                    {
                        currentNode = currentNode.left;
                    }
                    else
                    {
                        List<T> data = new List<T>();
                        getElements(currentNode.left, data);
                        root = root.right;
                        data.Sort();
                        T[] array = data.ToArray();
                        Filling(array);
                    }
                }
                count--;
            }
        }
        public void Balance()
        {
            List<T> data = new List<T>();
            getElements(root, data);
            root = null;
            count = 0;
            data.Sort();
            T[] array = data.ToArray();
            Filling(array);
        }
        public void Filling(T[] array)
        {
            if (array.Length != 0)
            {
                Insert(array[array.Length / 2]);
                T[] array1 = new T[array.Length / 2];
                T[] array2 = new T[array.Length / 2];
                int j = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (i < array.Length / 2)
                        array1[i] = array[i];
                    if (i > array.Length / 2)
                    {
                        array2[j] = array[i];
                        j++;
                    }
                }
                Filling(array1);
                Filling(array2); 
            }
        }
        public void getElements(TreeNode<T> currentNode, List<T> list)
        {
            list.Add(currentNode.data);
            if(currentNode.right != null)
                getElements(currentNode.right, list);
            if(currentNode.left != null)
                getElements(currentNode.left, list);
        }
    }
}
