let w=Number(readline()),h=readline(),t=readline().toUpperCase(),i,o,b,c,r
for(i=0;i<h;i++){r=readline();o="";for(let l of t){b=l.charCodeAt(0)-'A'.charCodeAt(0);b=b<0||b>25?26:b;c=b*w;o+=r.substring(c,c+w)}console.log(o)}
