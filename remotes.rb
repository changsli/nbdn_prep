%w[nninja94 changsli sweaver].each do|name|
  `git remote add #{name} git://github.com/#{name}/nbdn_prep.git`
end
