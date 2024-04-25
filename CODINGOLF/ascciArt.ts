const w:number=Number(readline()),h:number=Number(readline()),t:string=readline().toUpperCase();
for(let i:number=0;i<h;i++){const row:string=readline();let o:string="";for(let l of t){let ap=l.charCodeAt(0)-'A'.charCodeAt(0);ap=ap<0?26:ap>25?26:ap;let c=ap*w;o+=row.substring(c,c+w);}console.log(o)}
