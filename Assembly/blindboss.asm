;================================================================================
; Blind Boss fight
;--------------------------------------------------------------------------------


check_blind_boss_room:
	LDA $A0                             ; load room index (low byte)
	CMP #172 : BNE +                    ; Is is Thieve Town Boss Room
	LDA $09DE81 : BEQ +        			; Blind maiden does not need rescuing
	
	LDA $7EF3CC : JML Check_for_Blind_Fight
	+
	JML Initialize_Blind_Fight
	