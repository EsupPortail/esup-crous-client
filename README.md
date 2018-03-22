ESUP-CNOUS-CLIENT
=================

voir https://www.esup-portail.org/wiki/display/SGC/FAQ#FAQ-Peut-onencoderl'applicationCROUSquandonutilisedescartesvierges?

L'application esup-cnous-client permet la lecture et l'encodage del'application CNOUS sur une carte préalablement configurée

## Fonctionalitées

- CreationCarteCrous.exe et CreationCarteCrous.exe -h affiche l'aide
- CreationCarteCrous.exe -t controle de l'application. Retour true si tout est OK
- CreationCarteCrous.exe -l lit l'application CNOUS de la carte présente sur le lecteur
- CreationCarteCrous.exe -e XXXXXXXXXXX encore l'application CNOUS avec le numéro passé en parametre (le numéro doit comporté 15 caractères)

## Environnement

# Materiel

- un lecteur de carte compatible PC/SC
- une clé SAM OMNIKEY CardMan 6121 (l'application utilise automatiquement la clé de type 6121 comme clé SAM et l'autre lecteur de carte comme encodeur)

# Logiciel

- un environnement windows 64bits
- le framework .net 2 minimun

## Installation

Pour un fonctionnement avec le client esup-sgc-client, l'executable doit etre copier dans le dossier c:\cnousApi.
L'application necessite la presence de 4 dll présentes dans la solution dans le dossier Dlls:
- cnous_fournisseur_carte.dll (à demander auprès du CNOUS)
- libeay32.dll (openssl)
- libssl32.dll (openssl)
- pcsc_desfire.dll (springcard)

la version de la dll cnous doit etre x64

## Compilation

Pour compiler la solution il suffit de télécharger la dernière version de Visual Studio Community (https://www.visualstudio.com/fr/downloads/) ainsi que le framework .net version > 2


