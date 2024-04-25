let w=Number(readline()),h=Number(readline()),t=readline().toUpperCase(),i,o,b,c;
for(i=0;i<h;i++){const row=readline();o="";for(let l of t){b=l.charCodeAt(0)-'A'.charCodeAt(0);b=b<0?26:b>25?26:b;c=b*w;o+=row.substring(c,c+w);}console.log(o)}
