namespace DiggerClassic {
class _bag {
  internal int x,y,h,v,xr,yr,dir,wt,gt,fallh;
  internal bool wobbling,unfallen,exist;
internal void copyFrom (_bag t) {
 	x = t.x;
	y = t.y;
	h = t.h;
	v = t.v;
	xr = t.xr;
	yr = t.yr;
	dir = t.dir;
	wt = t.wt;
	gt = t.gt;
	fallh = t.fallh;
  wobbling = t.wobbling;
  unfallen = t.unfallen;
  exist = t.exist;
}
}
}