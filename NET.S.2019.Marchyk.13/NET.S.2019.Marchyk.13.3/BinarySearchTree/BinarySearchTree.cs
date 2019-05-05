using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class BinarySearchTree<T> : IEnumerable<T>
    where T : IComparable
{
        private int count;

        private TreeNode<T> head;

        #region Tree Node class
        class TreeNode<TNode> : IComparable<TNode>
            where TNode : IComparable
        {
            public TreeNode(TNode value)
            {
                Value = value;
            }

            public TreeNode<TNode> Left { get; set; }
            public TreeNode<TNode> Right { get; set; }
            public TNode Value { get; private set; }

            /// 
            /// Сравнивает текущий узел с данным.
            /// 
            /// Сравнение производится по полю Value.
            /// Метод возвращает 1, если значение текущего узла больше,
            /// чем переданного методу, -1, если меньше и 0, если они равны
            public int CompareTo(TNode other)
            {
                return Value.CompareTo(other);
            }

            public override string ToString()
            {
                if (Left == null)
                {
                    if (Right == null)
                        return $"Value: {Value}, left: empty, right: empty.";

                    return $"Value: {Value}, left: empty, right: {Right.Value}";
                }

                if (Right == null)
                    return $"Value: {Value}, left: {Left.Value}, right: empty.";

                return $"Value: {Value}, left: {Left.Value}, right: {Right.Value}.";
            }
        }
        #endregion

        public void Add(T value)
        {
            // Случай 1: Если дерево пустое, просто создаем корневой узел.
            if (head == null)
            {
                head = new TreeNode<T>(value);
            }
            // Случай 2: Дерево не пустое => 
            // ищем правильное место для вставки.
            else
            {
                AddElement(head, value);
            }

            count++;
        }

        private void AddElement(TreeNode<T> node, T value)
        {
            // Случай 1: Вставляемое значение меньше значения узла
            if (value.CompareTo(node.Value) < 0)
            {
                // Если нет левого поддерева, добавляем значение в левого ребенка,
                if (node.Left == null)
                {
                    node.Left = new TreeNode<T>(value);
                }
                else
                {
                    // в противном случае повторяем для левого поддерева.
                    AddElement(node.Left, value);
                }
            }
            // Случай 2: Вставляемое значение больше или равно значению узла.
            else
            {
                // Если нет правого поддерева, добавляем значение в правого ребенка,
                if (node.Right == null)
                {
                    node.Right = new TreeNode<T>(value);
                }
                else
                {
                    // в противном случае повторяем для правого поддерева.
                    AddElement(node.Right, value);
                }
            }
        }


        public bool Contains(T value)
        {
            TreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        private TreeNode<T> FindWithParent(T value, out TreeNode<T> parent)
        {
            // Попробуем найти значение в дереве.
            TreeNode<T> current = head;
            parent = null;

            // До тех пор, пока не нашли...
            while (current != null)
            {
                int result = current.CompareTo(value);

                if (result > 0)
                {
                    // Если искомое значение меньше, идем налево.
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // Если искомое значение больше, идем направо.
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    // Если равны, то останавливаемся
                    break;
                }
            }

            return current;
        }



        public IEnumerable<T> Preorder()
        {
            if (ReferenceEquals(head, null))
                throw new InvalidOperationException("Tree is empty!");

            var roots = new Stack<TreeNode<T>>();

            TreeNode<T> current = head;

            while (true)
            {
                if (current != null)
                {
                    roots.Push(current);
                    yield return current.Value;
                    current = current.Left;
                }
                else
                {
                    if (roots.Any())
                        current = roots.Pop().Right;
                    else
                        break;
                }
            }
        }

        public IEnumerable<T> Postorder() => DoPostOrder(head);

        private IEnumerable<T> DoPostOrder(TreeNode<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            if (node.Left != null)
            {
                foreach (var leftNode in DoPostOrder(node.Left))
                {
                    yield return leftNode;
                }
            }

            if (node.Right != null)
            {
                foreach (var rightNode in DoPostOrder(node.Right))
                {
                    yield return rightNode;
                }
            }

            yield return node.Value;
        }

        public IEnumerable<T> Inorder()
        {
            if (ReferenceEquals(head, null))
                throw new InvalidOperationException("Tree is empty!");

            var roots = new Stack<TreeNode<T>>();

            var current = head;

            bool isDone = false;

            while (!isDone)
            {
                if (!ReferenceEquals(current, null))
                {
                    roots.Push(current);
                    current = current.Left;
                }
                else
                {
                    if (!roots.Any())
                    {
                        isDone = true;
                    }
                    else
                    {
                        current = roots.Pop();
                        yield return current.Value;
                        current = current.Right;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator() => Inorder().GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Count can't be less then zero.");

                count = value;
            }
        }
    }
}
