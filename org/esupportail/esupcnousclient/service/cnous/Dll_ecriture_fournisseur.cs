/*
 * Created by SharpDevelop.
 * User: jerome.i
 * Date: 19/03/2013
 * Time: 09:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Text;

namespace Cnous_ecriture_fournisseur
{

	public abstract partial class DLL_ECRITURE_FOURNISSEUR
	{
	
		/* Il s'agit du "wrapper" de la dll, permettant d'utiliser ses fonctions	*/
		
		/* LOG	*/
		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "set_log")]
			public static extern int set_log(string logFile, int log_max_size, byte log_level);
		
		/* ACTIVATION	*/
		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "active_with_calypso_ex")]
			public static extern int active_with_calypso_ex (string samReaderName,
		                                     string samCalypsoReaderName,
		                                     string cardReaderName,
		                                     string szCnousParamsFileName );

		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "active_with_calypso")]
			public static extern int active_with_calypso ( string samReaderName,
		                                  string samCalypsoReaderName,
		                                  string cardReaderName,
		                                  string szCnousParamsFileName,
		                                  StringBuilder szErrorMessage);
		
		/* INITIALISATION	*/		
		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "initialise_ex")]
			public static extern int  initialise_ex (  ref char pbTypeDLL,
                      ref UInt32 pwVersionDLL,
                      byte[] abSamUID  );
							

		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "initialise")]
			public static extern int  initialise   ( StringBuilder szInitializeString,
                    StringBuilder szErrorMessage );

		
		/* PASSAGE DE CONTEXTE	*/
		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "utilise_contexte")]
			public static extern int utilise_contexte(IntPtr hContext);

		/* LIBERATION DES SAMS	*/
		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libere_sams")]
			public static extern int libere_sams();			
			
		
		/* 	RECUPERATION DES DONNEES DU FICHIER	*/
		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "recuperer_donnees_fichier")]
			public static extern int recuperer_donnees_fichier(ref byte cnous_id,
		                            byte[] crous_id,
                                byte[] issuer_id,
                                ref byte mapping_version,
                                byte[] dll_ver_min,
                                byte[] supplier_id,
                                byte[] card_num_min,
                                byte[] card_num_max );		
		
		/* CREATION */
		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "creation_ex")]
		public static extern int creation_ex  ( byte[] abNumCard,
                   	 byte[] abType,
                     byte[] abUid,  ref byte pbUidLen,
                     byte[] abNum,  ref byte pbNumLen,
                     byte[] abNfo,  ref byte pbNfoLen,
                     string szCsvFile);
		
		
		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "creation")]
			public static extern int creation   (StringBuilder szCardString, StringBuilder szErrorMessage, string szCsvFile);
		
			
		/* CREATION CARTE	*/
		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "creation_carte_ex")]
		public static extern int creation_carte_ex  ( byte[] abNumCard,
                   	 byte[] abType,
                     byte[] abUid,  ref byte pbUidLen,
                     byte[] abNum,  ref byte pbNumLen,
                     byte[] abNfo,  ref byte pbNfoLen,
                     string szCsvFile, 
                     IntPtr actual_hCard, ref IntPtr new_hCard);
		
		
		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "creation_carte")]
			public static extern int creation_carte   (StringBuilder szCardString, 
		                                           StringBuilder szErrorMessage, 
		                                           string szCsvFile,
		                                           IntPtr actual_hCard, ref IntPtr new_hCard);

        [DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ecriture")]
        public static extern int ecriture(StringBuilder szCardString, StringBuilder szErrorMessage, string szCsvFile);



        /* LECTURE	*/
        [DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "lecture_ex")]
		public static extern int lecture_ex   (  byte[] abZDC,
                     byte[] abType,
                     byte[] abUid,  ref byte pbUidLen,
                     byte[] abNum,  ref byte pbNumLen,
                     byte[] abNfo,  ref byte pbNfoLen );

		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "lecture")]
		public static extern int lecture      ( StringBuilder szCardString, StringBuilder szErrorMessage);		
		
		/* LECTURE CARTE	*/
		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "lecture_carte_ex")]
		public static extern int lecture_carte_ex   (  byte[] abZDC,
                     byte[] abType,
                     byte[] abUid,  ref byte pbUidLen,
                     byte[] abNum,  ref byte pbNumLen,
                     byte[] abNfo,  ref byte pbNfoLen,
                     IntPtr hCard);

		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "lecture_carte")]
			public static extern int lecture_carte      ( StringBuilder szCardString, StringBuilder szErrorMessage, IntPtr hCard);				
			
		
			
			
		/* EFFACEMENT	*/
		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "effacement_ex")]
			public static extern int effacement_ex  ();

		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "effacement")]
			public static extern int effacement   (  StringBuilder szErrorMessage );


		/* EFFACEMENT CARTE	*/
		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "effacement_carte_ex")]
			public static extern int effacement_carte_ex  (IntPtr actual_hCard, ref IntPtr new_hCard);

		[DllImport("cnous_fournisseur_carte.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "effacement_carte")]
			public static extern int effacement_carte   (  StringBuilder szErrorMessage, IntPtr actual_hCard, ref IntPtr new_hCard );
	
		

				
	}
}
