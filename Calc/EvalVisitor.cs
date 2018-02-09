using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;
using static System.Convert;

namespace Calc
{
    public class EvalVisitor: LabeledExprBaseVisitor<double>
    {
        public override double VisitFLOAT(LabeledExprParser.FLOATContext ctx)
        {
            return double.Parse(ctx.FLOAT().GetText());
        }
        public override double VisitMulDiv(LabeledExprParser.MulDivContext ctx)
        {
            double left = Visit(ctx.expr(0));
            double right = Visit(ctx.expr(1));
            if (ctx.op.Type == LabeledExprParser.MUL)
                return left * right;
            return left / right;
        }
        public override double VisitAddSub(LabeledExprParser.AddSubContext ctx)
        {
            double left = Visit(ctx.expr(0));
            double right = Visit(ctx.expr(1));
            if (ctx.op.Type == LabeledExprParser.ADD)
                return left + right;
            return left - right;
        }
        public override double VisitParens(LabeledExprParser.ParensContext ctx)
        {
            return Visit(ctx.expr()); 
        }
    }
}
