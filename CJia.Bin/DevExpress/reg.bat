for %%c in (DevExpress*.dll) do gacutil /u %%c
for %%c in (DevExpress*.dll) do sn -Vr %%c
for %%c in (DevExpress*.dll) do gacutil /if  %%c
for %%c in (DevExpress*.dll) do sn -Vu %%c