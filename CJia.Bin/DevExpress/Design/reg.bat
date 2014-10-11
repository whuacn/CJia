for %%c in (DevExpress*Design*.dll) do gacutil /u %%c
for %%c in (DevExpress*Design*.dll) do sn -Vr %%c
for %%c in (DevExpress*Design*.dll) do gacutil /if  %%c
for %%c in (DevExpress*Design*.dll) do sn -Vu %%c