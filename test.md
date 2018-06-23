#include <WINDOWS.H>
#include <STDIO.H>

LRESULT CALLBACK WinSunProc(
	HWND hwnd,
	UINT uMsg,
	WPARAM wParam,
	LPARAM lParam
);

int WINAPI WinMain(
	HINSTANCE hInstance,
	HINSTANCE hPrevInstance,
	LPSTR lpCmdLine,
	int nCmdShow
	)
{
	//设计一个窗体类
	WNDCLASS wndcls;
	wndcls.cbClsExtra =0 ;
	wndcls.cbWndExtra = 0;
	wndcls.hbrBackground = (HBRUSH)GetStockObject(BLACK_BRUSH);
	wndcls.hCursor = LoadCursor(NULL,IDC_CROSS);
	wndcls.hIcon = LoadIcon(NULL,IDI_ERROR);
	wndcls.lpfnWndProc = WinSunProc;
	wndcls.lpszClassName = "szh";
	wndcls.lpszMenuName=NULL;
	wndcls.style = CS_HREDRAW | CS_VREDRAW;
	RegisterClass(&wndcls);

	//创建窗口
	HWND hwnd;
	hwnd = CreateWindow("szh","http",WS_OVERLAPPEDWINDOW,
		0,0,600,400,NULL,NULL,hInstance,NULL);
	
	//刷新显示窗口
	ShowWindow(hwnd,SW_SHOWNORMAL);
	UpdateWindow(hwnd);
	
	//define message strcut, start message cycle
	MSG msg;
	while(GetMessage(&msg,NULL,0,0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);


	}

	return 0;

}


// 窗口过程函数
LRESULT CALLBACK WinSunProc(
	HWND hwnd,
	UINT uMsg,
	WPARAM wParam,
	LPARAM lParam)
{ 
	switch(uMsg) 
	{ 
	case  WM_CHAR:
		char szChar[20];
		sprintf(szChar,"Char code is %d",wParam);
		MessageBox(hwnd,szChar,"weixin",0);
		break;
	case WM_LBUTTONDBLCLK:
		MessageBox(hwnd,"moused clicked","weixin",0);
		HDC hdc;
		hdc = GetDC(hwnd);
		TextOut(hdc,0,50,"直接",strlen("dd"));
		ReleaseDC(hwnd,hdc);
		break;
	case WM_PAINT:
		HDC hDc;
		PAINTSTRUCT ps;
		hDc = BeginPaint(hwnd,&ps);
		TextOut(hDc,0,0,"wixindpend",strlen("dkdgjkla"));
		EndPaint(hwnd,&ps);
		break;
	case WM_CLOSE:
		if (IDYES == MessageBox(hwnd,"是否关闭窗口","adn",MB_YESNO))
		{
			DestroyWindow(hwnd);
		
		
		

		}
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hwnd,uMsg,wParam,lParam);
	}
	return 0;
}