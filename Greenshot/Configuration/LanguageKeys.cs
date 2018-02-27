#region Greenshot GNU General Public License

// Greenshot - a free and open source screenshot tool
// Copyright (C) 2007-2018 Thomas Braun, Jens Klingen, Robin Krom
// 
// For more information see: http://getgreenshot.org/
// The Greenshot project is hosted on GitHub https://github.com/greenshot/greenshot
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 1 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

#endregion

#region Usings

using System.Diagnostics.CodeAnalysis;

#endregion

namespace Greenshot.Configuration
{
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public enum LangKey
	{
		none,
		about_bugs,
		about_donations,
		about_host,
		about_icons,
		about_license,
		about_title,
		about_translation,
		application_title,
		bugreport_cancel,
		bugreport_info,
		bugreport_title,
		clipboard_error,
		clipboard_inuse,
		colorpicker_alpha,
		colorpicker_apply,
		colorpicker_blue,
		colorpicker_green,
		colorpicker_htmlcolor,
		colorpicker_recentcolors,
		colorpicker_red,
		colorpicker_title,
		colorpicker_transparent,
		config_unauthorizedaccess_write,
		contextmenu_about,
		contextmenu_capturearea,
		contextmenu_captureclipboard,
		contextmenu_capturefullscreen,
		contextmenu_capturefullscreen_all,
		contextmenu_capturefullscreen_left,
		contextmenu_capturefullscreen_top,
		contextmenu_capturefullscreen_right,
		contextmenu_capturefullscreen_bottom,
		contextmenu_capturelastregion,
		contextmenu_capturewindow,
		contextmenu_donate,
		contextmenu_exit,
		contextmenu_help,
		contextmenu_openfile,
		contextmenu_quicksettings,
		contextmenu_settings,
		contextmenu_captureie,
		contextmenu_openrecentcapture,
		editor_align_bottom,
		editor_align_center,
		editor_align_horizontal,
		editor_align_middle,
		editor_align_left,
		editor_align_right,
		editor_align_top,
		editor_align_vertical,
		editor_arrange,
		editor_arrowheads,
		editor_arrowheads_both,
		editor_arrowheads_end,
		editor_arrowheads_none,
		editor_arrowheads_start,
		editor_backcolor,
		editor_blur_radius,
		editor_bold,
		editor_brightness,
		editor_cancel,
		editor_clipboardfailed,
		editor_close,
		editor_close_on_save,
		editor_close_on_save_title,
		editor_confirm,
		editor_copyimagetoclipboard,
		editor_copypathtoclipboard,
		editor_copytoclipboard,
		editor_crop,
		editor_cursortool,
		editor_cuttoclipboard,
		editor_deleteelement,
		editor_downonelevel,
		editor_downtobottom,
		editor_drawarrow,
		editor_drawellipse,
		editor_drawhighlighter,
		editor_drawline,
		editor_drawfreehand,
		editor_drawrectangle,
		editor_drawtextbox,
		editor_duplicate,
		editor_edit,
		editor_email,
		editor_file,
		editor_fontsize,
		editor_forecolor,
		editor_highlight_area,
		editor_highlight_grayscale,
		editor_highlight_mode,
		editor_highlight_text,
		editor_highlight_magnify,
		editor_pixel_size,
		editor_imagesaved,
		editor_italic,
		editor_load_objects,
		editor_magnification_factor,
		editor_match_capture_size,
		editor_obfuscate,
		editor_obfuscate_blur,
		editor_obfuscate_mode,
		editor_obfuscate_pixelize,
		editor_object,
		editor_opendirinexplorer,
		editor_pastefromclipboard,
		editor_preview_quality,
		editor_print,
		editor_save,
		editor_save_objects,
		editor_saveas,
		editor_selectall,
		editor_senttoprinter,
		editor_shadow,
		editor_torn_edge,
		editor_border,
		editor_grayscale,
		editor_effects,
		editor_storedtoclipboard,
		editor_thickness,
		editor_title,
		editor_uponelevel,
		editor_uptotop,
		editor_autocrop,
		editor_undo,
		editor_redo,
		editor_insertwindow,
		editor_resetsize,
		error,
		error_multipleinstances,
		error_nowriteaccess,
		error_openfile,
		error_openlink,
		error_save,
		error_save_invalid_chars,
		help_title,
		jpegqualitydialog_choosejpegquality,
		qualitydialog_dontaskagain,
		qualitydialog_title,
		settings_reducecolors,
		print_error,
		printoptions_allowcenter,
		printoptions_allowenlarge,
		printoptions_allowrotate,
		printoptions_allowshrink,
		printoptions_colors,
		printoptions_dontaskagain,
		printoptions_pagelayout,
		printoptions_printcolor,
		printoptions_printgrayscale,
		printoptions_printmonochrome,
		printoptions_timestamp,
		printoptions_inverted,
		printoptions_title,
		quicksettings_destination_file,
		settings_alwaysshowqualitydialog,
		settings_alwaysshowprintoptionsdialog,
		settings_applicationsettings,
		settings_autostartshortcut,
		settings_capture,
		settings_capture_mousepointer,
		settings_capture_windows_interactive,
		settings_copypathtoclipboard,
		settings_destination,
		settings_destination_clipboard,
		settings_destination_editor,
		settings_destination_email,
		settings_destination_file,
		settings_destination_fileas,
		settings_destination_printer,
		settings_destination_picker,
		settings_editor,
		settings_filenamepattern,
		settings_general,
		settings_iecapture,
		settings_jpegquality,
		settings_qualitysettings,
		settings_language,
		settings_message_filenamepattern,
		settings_output,
		settings_playsound,
		settings_plugins,
		settings_plugins_name,
		settings_plugins_version,
		settings_plugins_createdby,
		settings_plugins_dllpath,
		settings_preferredfilesettings,
		settings_primaryimageformat,
		settings_printer,
		settings_printoptions,
		settings_registerhotkeys,
		settings_showflashlight,
		settings_storagelocation,
		settings_title,
		settings_tooltip_filenamepattern,
		settings_tooltip_language,
		settings_tooltip_primaryimageformat,
		settings_tooltip_registerhotkeys,
		settings_tooltip_storagelocation,
		settings_visualization,
		settings_shownotify,
		settings_waittime,
		settings_windowscapture,
		settings_window_capture_mode,
		settings_network,
		settings_checkperiod,
		settings_usedefaultproxy,
		tooltip_firststart,
		warning,
		warning_hotkeys,
		hotkeys,
		wait_ie_capture,
		update_found,
		exported_to
	}
}