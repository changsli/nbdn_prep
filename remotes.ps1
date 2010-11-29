("nninja94","changsli","sweaver") | foreach-object {
  git remote add $_ git://github.com/$_/nbdn_prep.git
}
