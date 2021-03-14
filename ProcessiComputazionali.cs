using System;
using System.Diagnostics;

namespace WPFSandBox
{
    // Iterazione & Ricorsione

    public enum SintatticoEnum
    {
        ITERATIVO,
        RICORSIVO
    }

    public enum ComputazionaleEnum
    {
        ITERATIVO,
        RICORSIVO
    }

    public class Processo
    {
        public readonly SintatticoInizio Sintattico = new SintatticoInizio();
        public readonly ComputazionaleInizio Computazionale = new ComputazionaleInizio();
    }

    public class SintatticoInizio
    {
        public readonly SintatticoIterativoInizio Iterativo = new SintatticoIterativoInizio();
        public readonly SintatticoRicorsivoInizio Ricorsivo = new SintatticoRicorsivoInizio();
    }

    public class ComputazionaleInizio
    {
        public readonly ComputazionaleIterativoInizio Iterativo = new ComputazionaleIterativoInizio();
        public readonly ComputazionaleRicorsivoInizio Ricorsivo = new ComputazionaleRicorsivoInizio();
    }

    public class SintatticoIterativoInizio
    {
        public readonly EComputazionale E = new EComputazionale(SintatticoEnum.ITERATIVO);
    }

    public class SintatticoRicorsivoInizio
    {
        public readonly EComputazionale E = new EComputazionale(SintatticoEnum.RICORSIVO);
    }

    public class ComputazionaleIterativoInizio
    {
        public readonly ESintattico E = new ESintattico(ComputazionaleEnum.ITERATIVO);
    }

    public class ComputazionaleRicorsivoInizio
    {
        public readonly ESintattico E = new ESintattico(ComputazionaleEnum.RICORSIVO);
    }

    public class EComputazionale
    {
        public readonly ComputazionaleFinale Computazionale;

        public EComputazionale(SintatticoEnum tipo)
        {
            Computazionale = new ComputazionaleFinale(tipo);
        }
    }

    public class ESintattico
    {
        public readonly SintatticoFinale Sintattico;

        public ESintattico(ComputazionaleEnum tipo)
        {
            Sintattico = new SintatticoFinale(tipo);
        }
    }

    public class ComputazionaleFinale
    {
        public readonly ComputazionaleIterativoFinale Iterativo;
        public readonly ComputazionaleRicorsivoFinale Ricorsivo;

        public ComputazionaleFinale(SintatticoEnum tipo)
        {
            Iterativo = new ComputazionaleIterativoFinale(tipo);
            Ricorsivo = new ComputazionaleRicorsivoFinale(tipo);
        }
    }

    public class SintatticoFinale
    {
        public readonly SintatticoIterativoFinale Iterativo;
        public readonly SintatticoRicorsivoFinale Ricorsivo;

        public SintatticoFinale(ComputazionaleEnum tipo)
        {
            Iterativo = new SintatticoIterativoFinale(tipo);
            Ricorsivo = new SintatticoRicorsivoFinale(tipo);
        }
    }

    public class ComputazionaleIterativoFinale
    {
        private SintatticoEnum _Tipo = SintatticoEnum.ITERATIVO;

        public ComputazionaleIterativoFinale(SintatticoEnum tipo)
        {
            _Tipo = tipo;
        }

        public int Compute(int n)
        {
            int ReturnValue = 0;
            switch (_Tipo)
            {
                case SintatticoEnum.ITERATIVO:
                    ReturnValue = Warehouse.ProcessoSintatticoIterativoEComputazionaleIterativo(n);
                    break;

                case SintatticoEnum.RICORSIVO:
                    ReturnValue = Warehouse.ProcessoSintatticoRicorsivaEProcessoComputazionaleIterativo(n);
                    break;
            }

            return ReturnValue;
        }
    }

    public class ComputazionaleRicorsivoFinale
    {
        private SintatticoEnum _Tipo = SintatticoEnum.ITERATIVO;

        public ComputazionaleRicorsivoFinale(SintatticoEnum tipo)
        {
            _Tipo = tipo;
        }

        public int Compute(int n)
        {
            int ReturnValue = 0;
            switch (_Tipo)
            {
                case SintatticoEnum.ITERATIVO:
                    ReturnValue = Warehouse.ProcessoSintatticoIterativoEProcessoComputazionaleRicorsivo(n);
                    break;

                case SintatticoEnum.RICORSIVO:
                    ReturnValue = Warehouse.ProcessoSintatticoRicorsivaEProcessoComputazionaleRicorsivo(n);
                    break;
            }

            return ReturnValue;
        }
    }

    public class SintatticoIterativoFinale
    {
        private ComputazionaleEnum _Tipo = ComputazionaleEnum.ITERATIVO;

        public SintatticoIterativoFinale(ComputazionaleEnum tipo)
        {
            _Tipo = tipo;
        }

        public int Compute(int n)
        {
            int ReturnValue = 0;
            switch (_Tipo)
            {
                case ComputazionaleEnum.ITERATIVO:
                    ReturnValue = Warehouse.ProcessoSintatticoIterativoEComputazionaleIterativo(n);
                    break;

                case ComputazionaleEnum.RICORSIVO:
                    ReturnValue = Warehouse.ProcessoSintatticoIterativoEProcessoComputazionaleRicorsivo(n);
                    break;
            }

            return ReturnValue;
        }
    }

    public class SintatticoRicorsivoFinale
    {
        private ComputazionaleEnum _Tipo = ComputazionaleEnum.ITERATIVO;

        public SintatticoRicorsivoFinale(ComputazionaleEnum tipo)
        {
            _Tipo = tipo;
        }

        public int Compute(int n)
        {
            int ReturnValue = 0;
            switch (_Tipo)
            {
                case ComputazionaleEnum.ITERATIVO:
                    ReturnValue = Warehouse.ProcessoSintatticoRicorsivaEProcessoComputazionaleIterativo(n);
                    break;

                case ComputazionaleEnum.RICORSIVO:
                    ReturnValue = Warehouse.ProcessoSintatticoRicorsivaEProcessoComputazionaleRicorsivo(n);
                    break;
            }

            return ReturnValue;
        }
    }

    public static class Warehouse
    {
        public static int ProcessoSintatticoIterativoEComputazionaleIterativo(int currentCounter)
        {
            // Sintassi Iterativa : c'è il for
            // Computazionale iterativo : calcola in avanti
            int acc = 1;
            for (int i = 1; i <= currentCounter; i++)
            {
                acc = acc * i;
            }

            return acc;
        }

        public static int ProcessoSintatticoRicorsivaEProcessoComputazionaleRicorsivo(int currentCounter)
        {
            // Sintassi Ricorsiva : c'è una chiamata (a se stessi)
            // Computazionale Ricorsiva : calcola all'indieto

            if (currentCounter > 0)
            {
                int nextCounter = currentCounter - 1;
                return ProcessoSintatticoRicorsivaEProcessoComputazionaleRicorsivo(nextCounter) * currentCounter;
            }
            else
            {
                return 1;
            }
        }

        public static int ProcessoSintatticoRicorsivaEProcessoComputazionaleIterativo(int currentMaxRecursion)
        {
            return ProcessoSintatticoRicorsivaEProcessoComputazionlmenteeIterativo(1, 1, currentMaxRecursion);
        }

        public static int ProcessoSintatticoRicorsivaEProcessoComputazionlmenteeIterativo(int currentAccumulator, int currentCounter, int currentMaxRecursion)
        {
            // Sintassi Ricorsiva : c'è una chiamata (a se stessi)
            // Computazionale Iterativo : calcola in avanti
            // Si può fare la tail-recursion optimization (TRO) , ma non nei linguaggi imperativi

            return currentCounter > currentMaxRecursion ? currentAccumulator : ProcessoSintatticoRicorsivaEProcessoComputazionlmenteeIterativo(currentAccumulator * currentCounter, currentCounter + 1, currentMaxRecursion);
        }

        public static int ProcessoSintatticoIterativoEProcessoComputazionaleRicorsivo(int currentCounter)
        {
            // Sintassi Iterativa : c'è il for
            // Computazionale Ricorsiva : calcola all'indietro
            // ??? Giusto ???   , oppure sta solo simulando lo stack
            NodeChain node = new NodeChain(currentCounter); ;
            for (int i = currentCounter - 1; i > 0; i--)
            {
                // Svolgo il problema
                node = new NodeChain(i, node);
            }
            return node.Compute();
        }

        public class NodeChain
        {
            private int _N = 0;
            private NodeChain _ParentNode = null;

            public NodeChain(int n, NodeChain parentNode)
            {
                _ParentNode = parentNode;
                _N = n;
            }

            public NodeChain(int n) : this(n, null)
            {
            }

            public int Compute()
            {
                NodeChain currentNode = this;
                int accumulator = currentNode._N;
                while (true)
                {
                    if (currentNode._ParentNode != null)
                    {
                        accumulator = accumulator * currentNode._ParentNode._N;
                        currentNode = currentNode._ParentNode;
                    }
                    else
                    {
                        break;
                    }
                }

                return accumulator;
            }
        }
    }

    public static class ProcessiComputazionaliTest
    {
        public static void Test001()
        {
            Processo processo = new Processo();

            Stopwatch sw = new Stopwatch();

            int n = 3;
            int LOOP = 1000000;
            int r = 0;

            sw.Restart();
            for (int i = 0; i < LOOP; i++)
            {
                r = processo.Sintattico.Iterativo.E.Computazionale.Iterativo.Compute(n);
            }
            sw.Stop();
            Console.WriteLine($"processo.Sintattico.Iterativo.E.Computazionale.Iterativo {r} : " + sw.ElapsedMilliseconds);

            sw.Restart();
            for (int i = 0; i < LOOP; i++)
            {
                r = processo.Sintattico.Iterativo.E.Computazionale.Ricorsivo.Compute(n);
            }
            sw.Stop();
            Console.WriteLine($"processo.Sintattico.Iterativo.E.Computazionale.Ricorsivo {r} : " + sw.ElapsedMilliseconds);

            sw.Restart();
            for (int i = 0; i < LOOP; i++)
            {
                r = processo.Sintattico.Ricorsivo.E.Computazionale.Iterativo.Compute(n);
            }
            sw.Stop();
            Console.WriteLine($"processo.Sintattico.Ricorsivo.E.ComputazComputazionaleionalmente.Iterativo {r} : " + sw.ElapsedMilliseconds);

            sw.Restart();
            for (int i = 0; i < LOOP; i++)
            {
                r = processo.Sintattico.Ricorsivo.E.Computazionale.Ricorsivo.Compute(n);
            }
            sw.Stop();
            Console.WriteLine($"processo.Sintattico.Ricorsivo.E.Computazionale.Ricorsivo {r} : " + sw.ElapsedMilliseconds);
        }
    }
}
