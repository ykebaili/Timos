/*
 * $Header: ocicob.h,v 1.1 1995/11/20 18:23:25 lchidamb Exp $ 
 */

/* Copyright (c) 1995 by Oracle Corporation */

/* NOTE:  See 'header_template.doc' in the 'doc' dve under the 'forms'
      directory for the header file template that includes instructions.
*/

/*
   NAME
     ocicob.h - <one-line expansion of the name>
   DESCRIPTION
     <short description of component this file declares/defines>
   RELATED DOCUMENTS

   INSPECTION STATUS
     Inspection date:
     Inspection status:
     Estimated increasing cost defects per page:
     Rule sets:

   ACCEPTANCE REVIEW STATUS
     Review date:
     Review status:
     Reviewers:

   PUBLIC FUNCTION(S)
     <list of external functions declared/defined - with one-line descriptions>
   PRIVATE FUNCTION(S)
     <list of static functions defined in .c file - with one-line descriptions>

   EXAMPLES

   NOTES
     <other useful comments, qualifications, etc.>
   MODIFIED   (MM/DD/YY)
    lchidamb   11/20/95 -  Creation
*/

#ifndef OCICOB_ORACLE
#define OCICOB_ORACLE

# ifndef S_ORACLE
# include <s.h>
# endif
#ifndef ORASTD
#include <orastd.h>
#endif
#ifndef SPARAMS
#include <sparams.h>
#endif
#ifndef OCIDFN
#include <ocidfn.h>
#endif

/*---------------------------------------------------------------------------
                     PUBLIC TYPES AND CONSTANTS
  ---------------------------------------------------------------------------*/

sword OBINDPS(/*_ struct cda_def *	cursor, ub1 *	opcode, text *	sqlvar, sb4 *	sqlvl, ub1 *	pvctx, sb4 *	progvl, sword *	ftype, sword *	scale, sb2 *	indp, ub2 *	alen, ub2 *	arcode, sb4 *	pv_skip, sb4 *	ind_skip, sb4 *	alen_skip, sb4 *	rc_skip, ub4 *	maxsiz, ub4 *	cursiz, text *	fmt, sb4 *	fmtl, sword *	fmtt _*/);
sword OBREAK(/*_ struct cda_def *	lda _*/);
sword OCAN(/*_ struct cda_def *	cursor _*/);
sword OCLOSE(/*_ struct cda_def *	cursor _*/);
sword OCOF(/*_ struct cda_def *	lda _*/);
sword OCOM(/*_ struct cda_def *	lda _*/);
sword OCON(/*_ struct cda_def *	lda _*/);
sword ODEFINPS(/*_ struct cda_def *	cursor, ub1 *	opcode, sword *	pos, ub1 *	bufctx, sb4 *	bufl, sword *	ftype, sword *	scale, sb2 *	indp, text *	fmt, sb4 *	fmtl, sword *	fmtt, ub2 *	rlen, ub2 *	rcode, sb4 *	pv_skip, sb4 *	ind_skip, sb4 *	alen_skip, sb4 *	rc_skip _*/);
sword ODESSP(/*_ struct cda_def *	cursor, text *	objnam, size_t *	onlen, ub1 *	rsv1, size_t *	rsv1ln, ub1 *	rsv2, size_t *	rsv2ln, ub2 *	ovrld, ub2 *	pos, ub2 *	level, text **	argnam, ub2 *	arnlen, ub2 *	dtype, ub1 *	defsup, ub1 *	mode, ub4 *	dtsiz, sb2 *	prec, sb2 *	scale, ub1 *	radix, ub4 *	spare, ub4 *	arrsiz _*/);
sword ODESCR(/*_ struct cda_def *	cursor, sword *	pos, sb4 *	dbsize, sb2 *	dbtype, sb1 *	cbuf, sb4 *	cbufl, sb4 *	dsize, sb2 *	prec, sb2 *	scale, sb2 *	nullok _*/);
sword OERHMS(/*_ struct cda_def *	lda, sb2 *	rcode, text *	buf, sword *	bufsiz _*/);
sword OERMSG(/*_ sb2 *	rcode, text *	buf _*/);
sword OEXEC(/*_ struct cda_def *	cursor _*/);
sword OEXFET(/*_ struct cda_def *	cursor, ub4 *	nrows, sword *	cancel, sword *	exact _*/);
sword OEXN(/*_ struct cda_def *	cursor, sword *	iters, sword *	rowoff _*/);
sword OFEN(/*_ struct cda_def *	cursor, sword *	nrows _*/);
sword OFETCH(/*_ struct cda_def *	cursor _*/);
sword OFLNG(/*_ struct cda_def *	cursor, sword *	pos, ub1 *	buf, sb4 *	bufl, sword *	dtype, ub4 *	retl, sb4 *	offset _*/);
sword OGETPI(/*_ struct cda_def *	cursor, ub1 *	piecep, dvoid **	ctxpp, ub4 *	iterp, ub4 *	indexp _*/);
sword OOPT(/*_ struct cda_def *	cursor, sword *	rbopt, sword *	waitopt _*/);
sword OPINIT(/*_ ub4 *	mode _*/);
sword OLOG(/*_ struct cda_def *	lda, ub1 *	hda, text *	uid, sword *	uidl, text *	pswd, sword *	pswdl, text *	conn, sword *	connl, ub4 *	mode _*/);
sword OLOGOF(/*_ struct cda_def *	lda _*/);
sword OOPEN(/*_ struct cda_def *	cursor, struct cda_def *	lda, text *	dbn, sword *	dbnl, sword *	arsize, text *	uid, sword *	uidl _*/);
sword OPARSE(/*_ struct cda_def *	cursor, text *	sqlstm, sb4 *	sqllen, sword *	defflg, ub4 *	lngflg _*/);
sword OROL(/*_ struct cda_def *	lda _*/);
sword OSETPI(/*_ struct cda_def *	cursor, ub1 *	piece, dvoid *	bufp, ub4 *	lenp _*/);
sword ONBSET(/*_ struct cda_def *	lda _*/);
sword ONBTST(/*_ struct cda_def *	lda _*/);
sword ONBCLR(/*_ struct cda_def *	lda _*/);
sword OGNFD(/*_ struct cda_def *	lda, dvoid *	fdp _*/);
sword OBNDRA(/*_ struct cda_def *	cursor, text *	sqlvar, sword *	sqlvl, ub1 *	progv, sword *	progvl, sword *	ftype, sword *	scale, sb2 *	indp, ub2 *	alen, ub2 *	arcode, ub4 *	maxsiz, ub4 *	cursiz, text *	fmt, sword *	fmtl, sword *	fmtt _*/);
sword OBNDRN(/*_ struct cda_def *	cursor, sword *	sqlvn, ub1 *	progv, sword *	progvl, sword *	ftype, sword *	scale, sb2 *	indp, text *	fmt, sword *	fmtl, sword *	fmtt _*/);
sword OBNDRV(/*_ struct cda_def *	cursor, text *	sqlvar, sword *	sqlvl, ub1 *	progv, sword *	progvl, sword *	ftype, sword *	scale, sb2 *	indp, text *	fmt, sword *	fmtl, sword *	fmtt _*/);
sword ODEFIN(/*_ struct cda_def *	cursor, sword *	pos, ub1 *	buf, sword *	bufl, sword *	ftype, sword *	scale, sb2 *	indp, text *	fmt, sword *	fmtl, sword *	fmtt, ub2 *	rlen, ub2 *	rcode _*/);
sword ONAME(/*_ struct cda_def *	cursor, sword *	pos, sb1 *	tbuf, sb2 *	tbufl, sb1 *	buf, sb2 *	bufl _*/);
sword ORLON(/*_ struct cda_def *	lda, ub1 *	hda, text *	uid, sword *	uidl, text *	pswd, sword *	pswdl, sword *	audit _*/);
sword OLON(/*_ struct cda_def *	lda, text *	uid, sword *	uidl, text *	pswd, sword *	pswdl, sword *	audit _*/);
sword OSQL3(/*_ struct cda_def *	cda, text *	sqlstm, sword *	sqllen _*/);
sword ODSC(/*_ struct cda_def *	cursor, sword *	pos, sb2 *	dbsize, sb2 *	fsize, sb2 *	rcode, sb2 *	dtype, sb1 *	buf, sb2 *	bufl, sb2 *	dsize _*/);

/*---------------------------------------------------------------------------
                     PRIVATE TYPES AND CONSTANTS
  ---------------------------------------------------------------------------*/


/*---------------------------------------------------------------------------
                           PUBLIC FUNCTIONS
  ---------------------------------------------------------------------------*/


/*---------------------------------------------------------------------------
                          PRIVATE FUNCTIONS
  ---------------------------------------------------------------------------*/


#endif                                              /* OCICOB_ORACLE */
 
