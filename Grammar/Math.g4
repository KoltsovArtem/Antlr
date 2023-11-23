grammar Math;

start: statement* EOF;

statement: assignment ';'
         | expression ';';

expression: ID
          | '(' expression ')'
          | expression '*' expression
          | expression '+' expression
          | INT ;

assignment: ID '=' expression;

ID : [a-zA-Z]+;
INT: [0-9]+;
WS : [ \t\n\r]+ -> skip;