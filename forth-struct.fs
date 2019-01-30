( align size -- alignedsize )
: ALIGNSIZE OVER + 1 - OVER / * ;

( -- voidalign voidsize )
: VOIDFLD 1 0 ;

( itemalign itemsize length -- arrayalign arraysize )
: ARRAYFLD 2 PICK ROT ALIGNSIZE * ;

( 1align 1size 2align 2size -- unionalign unionsize )
: 2UNIONFLD ROT MAX >R MAX R> ;

( 1align 1size ... nalign nsize n -- unionalign unionsize )
: UNIONFLD DUP 0 <= IF DROP VOIDFLD ELSE 1 ?DO 2UNIONFLD LOOP THEN ;

( -- cellalign cellsize )
: CELLFLD 1 CELLS DUP ;

( -- dcellalign dcellsize )
: DCELLFLD 2 CELLS DUP ;

( -- charalign charsize )
: CHARFLD 1 CHARS DUP ;

( -- flagalign flagsize )
: FLAGFLD 1 CHARS DUP ;

( -- structalign structsize )
: STRUCTURE: VOIDFLD ;

( structalign structsize fieldalign fieldsize -- structalign' structsize' )
: FIELDNAME
	OVER 4 ROLL MAX	>R
	>R SWAP ALIGNSIZE
	DUP R> + R> SWAP ROT
	CREATE , DOES> @ +
; 

( structalign structsize -- structalign structsize )
: STRUCTSIZE DUP CREATE , DOES> @ ;

( structalign structsize structsize' -- structalign structsize' )
: STRUCTSETSIZE NIP ;

( structalign structsize -- structalign structsize )
: STRUCTALIGN OVER CREATE , DOES> @ ;

( structalign structsize structalign' -- structalign' structsize )
: STRUCTSETALIGN ROT DROP SWAP ;

( structalign structsize -- structalign structsize )
: STRUCTEMBED 2DUP CREATE , , DOES> DUP CELL+ @ SWAP @ ;

( structalign structsize -- )
: ;STRUCTURE 2DROP ;
