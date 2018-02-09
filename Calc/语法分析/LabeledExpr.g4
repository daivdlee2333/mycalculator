grammar LabeledExpr; // rename to distinguish from Expr.g4

expr:   expr op=('*'|'/') expr      # MulDiv
    |   expr op=('+'|'-') expr      # AddSub
    
    |   FLOAT                       # FLOAT
    |   '(' expr ')'                # parens
    ;

MUL :   '*' ; // assigns token name to '*' used above in grammar
DIV :   '/' ;
ADD :   '+' ;
SUB :   '-' ;

//lexer
FLOAT:DIGIT+('.' DIGIT+)?;
DIGIT: '0'..'9';
WS  :   [ \t]+ -> skip ; // toss out whitespace
