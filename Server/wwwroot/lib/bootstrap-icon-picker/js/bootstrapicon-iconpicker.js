/*!
 * Bootstrap Icons
 * https://github.com/pixel-s-lab/bootstrapicon-iconpicker
 * This script is based on fontawesome-iconpicker by Javi Aguilar
 * @author Madalin Marius Stan, pixel.com.ro
 * @license MIT License
 * @see https://github.com/pixel-s-lab/bootstrapicon-iconpicker/blob/main/LICENSE
 */


(function (e) {
    if (typeof define === "function" && define.amd) {
        define(["jquery"], e);
    } else {
        e(jQuery);
    }
})(function (j) {
    j.ui = j.ui || {};
    var e = j.ui.version = "1.12.1";
    (function () {
        var r, y = Math.max, x = Math.abs, s = /left|center|right/, i = /top|center|bottom/,
            f = /[\+\-]\d+(\.[\d]+)?%?/, l = /^\w+/, c = /%$/, a = j.fn.pos;

        function q(e, a, t) {
            return [parseFloat(e[0]) * (c.test(e[0]) ? a / 100 : 1), parseFloat(e[1]) * (c.test(e[1]) ? t / 100 : 1)];
        }

        function C(e, a) {
            return parseInt(j.css(e, a), 10) || 0;
        }

        function t(e) {
            var a = e[0];
            if (a.nodeType === 9) {
                return {
                    width: e.width(),
                    height: e.height(),
                    offset: {
                        top: 0,
                        left: 0
                    }
                };
            }
            if (j.isWindow(a)) {
                return {
                    width: e.width(),
                    height: e.height(),
                    offset: {
                        top: e.scrollTop(),
                        left: e.scrollLeft()
                    }
                };
            }
            if (a.preventDefault) {
                return {
                    width: 0,
                    height: 0,
                    offset: {
                        top: a.pageY,
                        left: a.pageX
                    }
                };
            }
            return {
                width: e.outerWidth(),
                height: e.outerHeight(),
                offset: e.offset()
            };
        }

        j.pos = {
            scrollbarWidth: function () {
                if (r !== undefined) {
                    return r;
                }
                var e, a,
                    t = j("<div " + "style='display:block;position:absolute;width:50px;height:50px;overflow:hidden;'>" + "<div style='height:100px;width:auto;'></div></div>"),
                    s = t.children()[0];
                j("body").append(t);
                e = s.offsetWidth;
                t.css("overflow", "scroll");
                a = s.offsetWidth;
                if (e === a) {
                    a = t[0].clientWidth;
                }
                t.remove();
                return r = e - a;
            },
            getScrollInfo: function (e) {
                var a = e.isWindow || e.isDocument ? "" : e.element.css("overflow-x"),
                    t = e.isWindow || e.isDocument ? "" : e.element.css("overflow-y"),
                    s = a === "scroll" || a === "auto" && e.width < e.element[0].scrollWidth,
                    r = t === "scroll" || t === "auto" && e.height < e.element[0].scrollHeight;
                return {
                    width: r ? j.pos.scrollbarWidth() : 0,
                    height: s ? j.pos.scrollbarWidth() : 0
                };
            },
            getWithinInfo: function (e) {
                var a = j(e || window), t = j.isWindow(a[0]), s = !!a[0] && a[0].nodeType === 9, r = !t && !s;
                return {
                    element: a,
                    isWindow: t,
                    isDocument: s,
                    offset: r ? j(e).offset() : {
                        left: 0,
                        top: 0
                    },
                    scrollLeft: a.scrollLeft(),
                    scrollTop: a.scrollTop(),
                    width: a.outerWidth(),
                    height: a.outerHeight()
                };
            }
        };
        j.fn.pos = function (h) {
            if (!h || !h.of) {
                return a.apply(this, arguments);
            }
            h = j.extend({}, h);
            var m, p, d, u, T, e, g = j(h.of), b = j.pos.getWithinInfo(h.within), k = j.pos.getScrollInfo(b),
                w = (h.collision || "flip").split(" "), v = {};
            e = t(g);
            if (g[0].preventDefault) {
                h.at = "left top";
            }
            p = e.width;
            d = e.height;
            u = e.offset;
            T = j.extend({}, u);
            j.each(["my", "at"], function () {
                var e = (h[this] || "").split(" "), a, t;
                if (e.length === 1) {
                    e = s.test(e[0]) ? e.concat(["center"]) : i.test(e[0]) ? ["center"].concat(e) : ["center", "center"];
                }
                e[0] = s.test(e[0]) ? e[0] : "center";
                e[1] = i.test(e[1]) ? e[1] : "center";
                a = f.exec(e[0]);
                t = f.exec(e[1]);
                v[this] = [a ? a[0] : 0, t ? t[0] : 0];
                h[this] = [l.exec(e[0])[0], l.exec(e[1])[0]];
            });
            if (w.length === 1) {
                w[1] = w[0];
            }
            if (h.at[0] === "right") {
                T.left += p;
            } else if (h.at[0] === "center") {
                T.left += p / 2;
            }
            if (h.at[1] === "bottom") {
                T.top += d;
            } else if (h.at[1] === "center") {
                T.top += d / 2;
            }
            m = q(v.at, p, d);
            T.left += m[0];
            T.top += m[1];
            return this.each(function () {
                var t, e, f = j(this), l = f.outerWidth(), c = f.outerHeight(), a = C(this, "marginLeft"),
                    s = C(this, "marginTop"), r = l + a + C(this, "marginRight") + k.width,
                    i = c + s + C(this, "marginBottom") + k.height, o = j.extend({}, T),
                    n = q(v.my, f.outerWidth(), f.outerHeight());
                if (h.my[0] === "right") {
                    o.left -= l;
                } else if (h.my[0] === "center") {
                    o.left -= l / 2;
                }
                if (h.my[1] === "bottom") {
                    o.top -= c;
                } else if (h.my[1] === "center") {
                    o.top -= c / 2;
                }
                o.left += n[0];
                o.top += n[1];
                t = {
                    marginLeft: a,
                    marginTop: s
                };
                j.each(["left", "top"], function (e, a) {
                    if (j.ui.pos[w[e]]) {
                        j.ui.pos[w[e]][a](o, {
                            targetWidth: p,
                            targetHeight: d,
                            elemWidth: l,
                            elemHeight: c,
                            collisionPosition: t,
                            collisionWidth: r,
                            collisionHeight: i,
                            offset: [m[0] + n[0], m[1] + n[1]],
                            my: h.my,
                            at: h.at,
                            within: b,
                            elem: f
                        });
                    }
                });
                if (h.using) {
                    e = function (e) {
                        var a = u.left - o.left, t = a + p - l, s = u.top - o.top, r = s + d - c, i = {
                            target: {
                                element: g,
                                left: u.left,
                                top: u.top,
                                width: p,
                                height: d
                            },
                            element: {
                                element: f,
                                left: o.left,
                                top: o.top,
                                width: l,
                                height: c
                            },
                            horizontal: t < 0 ? "left" : a > 0 ? "right" : "center",
                            vertical: r < 0 ? "top" : s > 0 ? "bottom" : "middle"
                        };
                        if (p < l && x(a + t) < p) {
                            i.horizontal = "center";
                        }
                        if (d < c && x(s + r) < d) {
                            i.vertical = "middle";
                        }
                        if (y(x(a), x(t)) > y(x(s), x(r))) {
                            i.important = "horizontal";
                        } else {
                            i.important = "vertical";
                        }
                        h.using.call(this, e, i);
                    };
                }
                f.offset(j.extend(o, {
                    using: e
                }));
            });
        };
        j.ui.pos = {
            _trigger: function (e, a, t, s) {
                if (a.elem) {
                    a.elem.trigger({
                        type: t,
                        position: e,
                        positionData: a,
                        triggered: s
                    });
                }
            },
            fit: {
                left: function (e, a) {
                    j.ui.pos._trigger(e, a, "posCollide", "fitLeft");
                    var t = a.within, s = t.isWindow ? t.scrollLeft : t.offset.left, r = t.width,
                        i = e.left - a.collisionPosition.marginLeft, f = s - i, l = i + a.collisionWidth - r - s, c;
                    if (a.collisionWidth > r) {
                        if (f > 0 && l <= 0) {
                            c = e.left + f + a.collisionWidth - r - s;
                            e.left += f - c;
                        } else if (l > 0 && f <= 0) {
                            e.left = s;
                        } else {
                            if (f > l) {
                                e.left = s + r - a.collisionWidth;
                            } else {
                                e.left = s;
                            }
                        }
                    } else if (f > 0) {
                        e.left += f;
                    } else if (l > 0) {
                        e.left -= l;
                    } else {
                        e.left = y(e.left - i, e.left);
                    }
                    j.ui.pos._trigger(e, a, "posCollided", "fitLeft");
                },
                top: function (e, a) {
                    j.ui.pos._trigger(e, a, "posCollide", "fitTop");
                    var t = a.within, s = t.isWindow ? t.scrollTop : t.offset.top, r = a.within.height,
                        i = e.top - a.collisionPosition.marginTop, f = s - i, l = i + a.collisionHeight - r - s, c;
                    if (a.collisionHeight > r) {
                        if (f > 0 && l <= 0) {
                            c = e.top + f + a.collisionHeight - r - s;
                            e.top += f - c;
                        } else if (l > 0 && f <= 0) {
                            e.top = s;
                        } else {
                            if (f > l) {
                                e.top = s + r - a.collisionHeight;
                            } else {
                                e.top = s;
                            }
                        }
                    } else if (f > 0) {
                        e.top += f;
                    } else if (l > 0) {
                        e.top -= l;
                    } else {
                        e.top = y(e.top - i, e.top);
                    }
                    j.ui.pos._trigger(e, a, "posCollided", "fitTop");
                }
            },
            flip: {
                left: function (e, a) {
                    j.ui.pos._trigger(e, a, "posCollide", "flipLeft");
                    var t = a.within, s = t.offset.left + t.scrollLeft, r = t.width,
                        i = t.isWindow ? t.scrollLeft : t.offset.left, f = e.left - a.collisionPosition.marginLeft,
                        l = f - i, c = f + a.collisionWidth - r - i,
                        o = a.my[0] === "left" ? -a.elemWidth : a.my[0] === "right" ? a.elemWidth : 0,
                        n = a.at[0] === "left" ? a.targetWidth : a.at[0] === "right" ? -a.targetWidth : 0,
                        h = -2 * a.offset[0], m, p;
                    if (l < 0) {
                        m = e.left + o + n + h + a.collisionWidth - r - s;
                        if (m < 0 || m < x(l)) {
                            e.left += o + n + h;
                        }
                    } else if (c > 0) {
                        p = e.left - a.collisionPosition.marginLeft + o + n + h - i;
                        if (p > 0 || x(p) < c) {
                            e.left += o + n + h;
                        }
                    }
                    j.ui.pos._trigger(e, a, "posCollided", "flipLeft");
                },
                top: function (e, a) {
                    j.ui.pos._trigger(e, a, "posCollide", "flipTop");
                    var t = a.within, s = t.offset.top + t.scrollTop, r = t.height,
                        i = t.isWindow ? t.scrollTop : t.offset.top, f = e.top - a.collisionPosition.marginTop,
                        l = f - i, c = f + a.collisionHeight - r - i, o = a.my[1] === "top",
                        n = o ? -a.elemHeight : a.my[1] === "bottom" ? a.elemHeight : 0,
                        h = a.at[1] === "top" ? a.targetHeight : a.at[1] === "bottom" ? -a.targetHeight : 0,
                        m = -2 * a.offset[1], p, d;
                    if (l < 0) {
                        d = e.top + n + h + m + a.collisionHeight - r - s;
                        if (d < 0 || d < x(l)) {
                            e.top += n + h + m;
                        }
                    } else if (c > 0) {
                        p = e.top - a.collisionPosition.marginTop + n + h + m - i;
                        if (p > 0 || x(p) < c) {
                            e.top += n + h + m;
                        }
                    }
                    j.ui.pos._trigger(e, a, "posCollided", "flipTop");
                }
            },
            flipfit: {
                left: function () {
                    j.ui.pos.flip.left.apply(this, arguments);
                    j.ui.pos.fit.left.apply(this, arguments);
                },
                top: function () {
                    j.ui.pos.flip.top.apply(this, arguments);
                    j.ui.pos.fit.top.apply(this, arguments);
                }
            }
        };
        (function () {
            var e, a, t, s, r, i = document.getElementsByTagName("body")[0], f = document.createElement("div");
            e = document.createElement(i ? "div" : "body");
            t = {
                visibility: "hidden",
                width: 0,
                height: 0,
                border: 0,
                margin: 0,
                background: "none"
            };
            if (i) {
                j.extend(t, {
                    position: "absolute",
                    left: "-1000px",
                    top: "-1000px"
                });
            }
            for (r in t) {
                e.style[r] = t[r];
            }
            e.appendChild(f);
            a = i || document.documentElement;
            a.insertBefore(e, a.firstChild);
            f.style.cssText = "position: absolute; left: 10.7432222px;";
            s = j(f).offset().left;
            j.support.offsetFractions = s > 10 && s < 11;
            e.innerHTML = "";
            a.removeChild(e);
        })();
    })();
    var a = j.ui.position;
});

(function (e) {
    "use strict";
    if (typeof define === "function" && define.amd) {
        define(["jquery"], e);
    } else if (window.jQuery && !window.jQuery.fn.iconpicker) {
        e(window.jQuery);
    }
})(function (c) {
    "use strict";
    var f = {
        isEmpty: function (e) {
            return e === false || e === "" || e === null || e === undefined;
        },
        isEmptyObject: function (e) {
            return this.isEmpty(e) === true || e.length === 0;
        },
        isElement: function (e) {
            return c(e).length > 0;
        },
        isString: function (e) {
            return typeof e === "string" || e instanceof String;
        },
        isArray: function (e) {
            return c.isArray(e);
        },
        inArray: function (e, a) {
            return c.inArray(e, a) !== -1;
        },
        throwError: function (e) {
            throw "Font Awesome Icon Picker Exception: " + e;
        }
    };
    var t = function (e, a) {
        this._id = t._idCounter++;
        this.element = c(e).addClass("iconpicker-element");
        this._trigger("iconpickerCreate", {
            iconpickerValue: this.iconpickerValue
        });
        this.options = c.extend({}, t.defaultOptions, this.element.data(), a);
        this.options.templates = c.extend({}, t.defaultOptions.templates, this.options.templates);
        this.options.originalPlacement = this.options.placement;
        this.container = f.isElement(this.options.container) ? c(this.options.container) : false;
        if (this.container === false) {
            if (this.element.is(".dropdown-toggle")) {
                this.container = c("~ .dropdown-menu:first", this.element);
            } else {
                this.container = this.element.is("input,textarea,button,.btn") ? this.element.parent() : this.element;
            }
        }
        this.container.addClass("iconpicker-container");
        if (this.isDropdownMenu()) {
            this.options.placement = "inline";
        }
        this.input = this.element.is("input,textarea") ? this.element.addClass("iconpicker-input") : false;
        if (this.input === false) {
            this.input = this.container.find(this.options.input);
            if (!this.input.is("input,textarea")) {
                this.input = false;
            }
        }
        this.component = this.isDropdownMenu() ? this.container.parent().find(this.options.component) : this.container.find(this.options.component);
        if (this.component.length === 0) {
            this.component = false;
        } else {
            this.component.find("i").addClass("iconpicker-component");
        }
        this._createPopover();
        this._createIconpicker();
        if (this.getAcceptButton().length === 0) {
            this.options.mustAccept = false;
        }
        if (this.isInputGroup()) {
            this.container.parent().append(this.popover);
        } else {
            this.container.append(this.popover);
        }
        this._bindElementEvents();
        this._bindWindowEvents();
        this.update(this.options.selected);
        if (this.isInline()) {
            this.show();
        }
        this._trigger("iconpickerCreated", {
            iconpickerValue: this.iconpickerValue
        });
    };
    t._idCounter = 0;
    t.defaultOptions = {
        title: false,
        selected: false,
        defaultValue: false,
        placement: "bottom",
        collision: "none",
        animation: true,
        hideOnSelect: false,
        showFooter: false,
        searchInFooter: false,
        mustAccept: false,
        selectedCustomClass: "bg-primary",
        icons: [],
        fullClassFormatter: function (e) {
            return e;
        },
        input: "input,.iconpicker-input",
        inputSearch: false,
        container: false,
        component: ".input-group-addon,.iconpicker-component",
        templates: {
            popover: '<div class="iconpicker-popover popover" role="tooltip"><div class="arrow"></div>' + '<div class="popover-title"></div><div class="popover-content"></div></div>',
            footer: '<div class="popover-footer"></div>',
            buttons: '<button class="iconpicker-btn iconpicker-btn-cancel btn btn-default btn-sm">Cancel</button>' + ' <button class="iconpicker-btn iconpicker-btn-accept btn btn-primary btn-sm">Accept</button>',
            search: '<input type="search" class="form-control iconpicker-search" placeholder="Type to filter" />',
            iconpicker: '<div class="iconpicker"><div class="iconpicker-items"></div></div>',
            iconpickerItem: '<a role="button" href="javascript:;" class="iconpicker-item"><i></i></a>'
        }
    };
    t.batch = function (e, a) {
        var t = Array.prototype.slice.call(arguments, 2);
        return c(e).each(function () {
            var e = c(this).data("iconpicker");
            if (!!e) {
                e[a].apply(e, t);
            }
        });
    };
    t.prototype = {
        constructor: t,
        options: {},
        _id: 0,
        _trigger: function (e, a) {
            a = a || {};
            this.element.trigger(c.extend({
                type: e,
                iconpickerInstance: this
            }, a));
        },
        _createPopover: function () {
            this.popover = c(this.options.templates.popover);
            var e = this.popover.find(".popover-title");
            if (!!this.options.title) {
                e.append(c('<div class="popover-title-text">' + this.options.title + "</div>"));
            }
            if (this.hasSeparatedSearchInput() && !this.options.searchInFooter) {
                e.append(this.options.templates.search);
            } else if (!this.options.title) {
                e.remove();
            }
            if (this.options.showFooter && !f.isEmpty(this.options.templates.footer)) {
                var a = c(this.options.templates.footer);
                if (this.hasSeparatedSearchInput() && this.options.searchInFooter) {
                    a.append(c(this.options.templates.search));
                }
                if (!f.isEmpty(this.options.templates.buttons)) {
                    a.append(c(this.options.templates.buttons));
                }
                this.popover.append(a);
            }
            if (this.options.animation === true) {
                this.popover.addClass("fade show");
            }
            return this.popover;
        },
        _createIconpicker: function () {
            var t = this;
            this.iconpicker = c(this.options.templates.iconpicker);
            var e = function (e) {
                var a = c(this);
                if (a.is("i")) {
                    a = a.parent();
                }
                t._trigger("iconpickerSelect", {
                    iconpickerItem: a,
                    iconpickerValue: t.iconpickerValue
                });
                if (t.options.mustAccept === false) {
                    t.update(a.data("iconpickerValue"));
                    t._trigger("iconpickerSelected", {
                        iconpickerItem: this,
                        iconpickerValue: t.iconpickerValue
                    });
                } else {
                    t.update(a.data("iconpickerValue"), true);
                }
                if (t.options.hideOnSelect && t.options.mustAccept === false) {
                    t.hide();
                }
            };
            var a = c(this.options.templates.iconpickerItem);
            var s = [];
            for (var r in this.options.icons) {
                if (typeof this.options.icons[r].title === "string") {
                    var i = a.clone();
                    i.find("i").addClass(this.options.fullClassFormatter(this.options.icons[r].title));
                    i.data("iconpickerValue", this.options.icons[r].title).on("click.iconpicker", e);
                    i.attr("title", "." + this.options.icons[r].title);
                    if (this.options.icons[r].searchTerms.length > 0) {
                        var f = "";
                        for (var l = 0; l < this.options.icons[r].searchTerms.length; l++) {
                            f = f + this.options.icons[r].searchTerms[l] + " ";
                        }
                        i.attr("data-search-terms", f);
                    }
                    s.push(i);
                }
            }
            this.iconpicker.find(".iconpicker-items").append(s);
            this.popover.find(".popover-content").append(this.iconpicker);
            return this.iconpicker;
        },
        _isEventInsideIconpicker: function (e) {
            var a = c(e.target);
            if ((!a.hasClass("iconpicker-element") || a.hasClass("iconpicker-element") && !a.is(this.element)) && a.parents(".iconpicker-popover").length === 0) {
                return false;
            }
            return true;
        },
        _bindElementEvents: function () {
            var a = this;
            this.getSearchInput().on("keyup.iconpicker", function () {
                a.filter(c(this).val().toLowerCase());
            });
            this.getAcceptButton().on("click.iconpicker", function () {
                var e = a.iconpicker.find(".iconpicker-selected").get(0);
                a.update(a.iconpickerValue);
                a._trigger("iconpickerSelected", {
                    iconpickerItem: e,
                    iconpickerValue: a.iconpickerValue
                });
                if (!a.isInline()) {
                    a.hide();
                }
            });
            this.getCancelButton().on("click.iconpicker", function () {
                if (!a.isInline()) {
                    a.hide();
                }
            });
            this.element.on("focus.iconpicker", function (e) {
                a.show();
                e.stopPropagation();
            });
            if (this.hasComponent()) {
                this.component.on("click.iconpicker", function () {
                    a.toggle();
                });
            }
            if (this.hasInput()) {
                this.input.on("keyup.iconpicker", function (e) {
                    if (!f.inArray(e.keyCode, [38, 40, 37, 39, 16, 17, 18, 9, 8, 91, 93, 20, 46, 186, 190, 46, 78, 188, 44, 86])) {
                        a.update();
                    } else {
                        a._updateFormGroupStatus(a.getValid(this.value) !== false);
                    }
                    if (a.options.inputSearch === true) {
                        a.filter(c(this).val().toLowerCase());
                    }
                });
            }
        },
        _bindWindowEvents: function () {
            var e = c(window.document);
            var a = this;
            var t = ".iconpicker.inst" + this._id;
            c(window).on("resize.iconpicker" + t + " orientationchange.iconpicker" + t, function (e) {
                if (a.popover.hasClass("in")) {
                    a.updatePlacement();
                }
            });
            if (!a.isInline()) {
                e.on("mouseup" + t, function (e) {
                    if (!a._isEventInsideIconpicker(e) && !a.isInline()) {
                        a.hide();
                    }
                });
            }
        },
        _unbindElementEvents: function () {
            this.popover.off(".iconpicker");
            this.element.off(".iconpicker");
            if (this.hasInput()) {
                this.input.off(".iconpicker");
            }
            if (this.hasComponent()) {
                this.component.off(".iconpicker");
            }
            if (this.hasContainer()) {
                this.container.off(".iconpicker");
            }
        },
        _unbindWindowEvents: function () {
            c(window).off(".iconpicker.inst" + this._id);
            c(window.document).off(".iconpicker.inst" + this._id);
        },
        updatePlacement: function (e, a) {
            e = e || this.options.placement;
            this.options.placement = e;
            a = a || this.options.collision;
            a = a === true ? "flip" : a;
            var t = {
                at: "right bottom",
                my: "right top",
                of: this.hasInput() && !this.isInputGroup() ? this.input : this.container,
                collision: a === true ? "flip" : a,
                within: window
            };
            this.popover.removeClass("inline topLeftCorner topLeft top topRight topRightCorner " + "rightTop right rightBottom bottomRight bottomRightCorner " + "bottom bottomLeft bottomLeftCorner leftBottom left leftTop");
            if (typeof e === "object") {
                return this.popover.pos(c.extend({}, t, e));
            }
            switch (e) {
                case "inline": {
                    t = false;
                }
                    break;

                case "topLeftCorner": {
                    t.my = "right bottom";
                    t.at = "left top";
                }
                    break;

                case "topLeft": {
                    t.my = "left bottom";
                    t.at = "left top";
                }
                    break;

                case "top": {
                    t.my = "center bottom";
                    t.at = "center top";
                }
                    break;

                case "topRight": {
                    t.my = "right bottom";
                    t.at = "right top";
                }
                    break;

                case "topRightCorner": {
                    t.my = "left bottom";
                    t.at = "right top";
                }
                    break;

                case "rightTop": {
                    t.my = "left bottom";
                    t.at = "right center";
                }
                    break;

                case "right": {
                    t.my = "left center";
                    t.at = "right center";
                }
                    break;

                case "rightBottom": {
                    t.my = "left top";
                    t.at = "right center";
                }
                    break;

                case "bottomRightCorner": {
                    t.my = "left top";
                    t.at = "right bottom";
                }
                    break;

                case "bottomRight": {
                    t.my = "right top";
                    t.at = "right bottom";
                }
                    break;

                case "bottom": {
                    t.my = "center top";
                    t.at = "center bottom";
                }
                    break;

                case "bottomLeft": {
                    t.my = "left top";
                    t.at = "left bottom";
                }
                    break;

                case "bottomLeftCorner": {
                    t.my = "right top";
                    t.at = "left bottom";
                }
                    break;

                case "leftBottom": {
                    t.my = "right top";
                    t.at = "left center";
                }
                    break;

                case "left": {
                    t.my = "right center";
                    t.at = "left center";
                }
                    break;

                case "leftTop": {
                    t.my = "right bottom";
                    t.at = "left center";
                }
                    break;

                default: {
                    return false;
                }
                    break;
            }
            this.popover.css({
                display: this.options.placement === "inline" ? "" : "block"
            });
            if (t !== false) {
                this.popover.pos(t).css("maxWidth", c(window).width() - this.container.offset().left - 5);
            } else {
                this.popover.css({
                    top: "auto",
                    right: "auto",
                    bottom: "auto",
                    left: "auto",
                    maxWidth: "none"
                });
            }
            this.popover.addClass(this.options.placement);
            return true;
        },
        _updateComponents: function () {
            this.iconpicker.find(".iconpicker-item.iconpicker-selected").removeClass("iconpicker-selected " + this.options.selectedCustomClass);
            if (this.iconpickerValue) {
                this.iconpicker.find("." + this.options.fullClassFormatter(this.iconpickerValue).replace(/ /g, ".")).parent().addClass("iconpicker-selected " + this.options.selectedCustomClass);
            }
            if (this.hasComponent()) {
                var e = this.component.find("i");
                if (e.length > 0) {
                    e.attr("class", this.options.fullClassFormatter(this.iconpickerValue));
                } else {
                    this.component.html(this.getHtml());
                }
            }
        },
        _updateFormGroupStatus: function (e) {
            if (this.hasInput()) {
                if (e !== false) {
                    this.input.parents(".form-group:first").removeClass("has-error");
                } else {
                    this.input.parents(".form-group:first").addClass("has-error");
                }
                return true;
            }
            return false;
        },
        getValid: function (e) {
            if (!f.isString(e)) {
                e = "";
            }
            var a = e === "";
            e = c.trim(e);
            var t = false;
            for (var s = 0; s < this.options.icons.length; s++) {
                if (this.options.icons[s].title === e) {
                    t = true;
                    break;
                }
            }
            if (t || a) {
                return e;
            }
            return false;
        },
        setValue: function (e) {
            var a = this.getValid(e);
            if (a !== false) {
                this.iconpickerValue = a;
                this._trigger("iconpickerSetValue", {
                    iconpickerValue: a
                });
                return this.iconpickerValue;
            } else {
                this._trigger("iconpickerInvalid", {
                    iconpickerValue: e
                });
                return false;
            }
        },
        getHtml: function () {
            return '<i class="' + this.options.fullClassFormatter(this.iconpickerValue) + '"></i>';
        },
        setSourceValue: function (e) {
            e = this.setValue(e);
            if (e !== false && e !== "") {
                if (this.hasInput()) {
                    this.input.val(this.iconpickerValue);
                } else {
                    this.element.data("iconpickerValue", this.iconpickerValue);
                }
                this._trigger("iconpickerSetSourceValue", {
                    iconpickerValue: e
                });
            }
            return e;
        },
        getSourceValue: function (e) {
            e = e || this.options.defaultValue;
            var a = e;
            if (this.hasInput()) {
                a = this.input.val();
            } else {
                a = this.element.data("iconpickerValue");
            }
            if (a === undefined || a === "" || a === null || a === false) {
                a = e;
            }
            return a;
        },
        hasInput: function () {
            return this.input !== false;
        },
        isInputSearch: function () {
            return this.hasInput() && this.options.inputSearch === true;
        },
        isInputGroup: function () {
            return this.container.is(".input-group");
        },
        isDropdownMenu: function () {
            return this.container.is(".dropdown-menu");
        },
        hasSeparatedSearchInput: function () {
            return this.options.templates.search !== false && !this.isInputSearch();
        },
        hasComponent: function () {
            return this.component !== false;
        },
        hasContainer: function () {
            return this.container !== false;
        },
        getAcceptButton: function () {
            return this.popover.find(".iconpicker-btn-accept");
        },
        getCancelButton: function () {
            return this.popover.find(".iconpicker-btn-cancel");
        },
        getSearchInput: function () {
            return this.popover.find(".iconpicker-search");
        },
        filter: function (r) {
            if (f.isEmpty(r)) {
                this.iconpicker.find(".iconpicker-item").show();
                return c(false);
            } else {
                var i = [];
                this.iconpicker.find(".iconpicker-item").each(function () {
                    var e = c(this);
                    var a = e.attr("title").toLowerCase();
                    var t = e.attr("data-search-terms") ? e.attr("data-search-terms").toLowerCase() : "";
                    a = a + " " + t;
                    var s = false;
                    try {
                        s = new RegExp("(^|\\W)" + r, "g");
                    } catch (e) {
                        s = false;
                    }
                    if (s !== false && a.match(s)) {
                        i.push(e);
                        e.show();
                    } else {
                        e.hide();
                    }
                });
                return i;
            }
        },
        show: function () {
            if (this.popover.hasClass("in")) {
                return false;
            }
            c.iconpicker.batch(c(".iconpicker-popover.in:not(.inline)").not(this.popover), "hide");
            this._trigger("iconpickerShow", {
                iconpickerValue: this.iconpickerValue
            });
            this.updatePlacement();
            this.popover.addClass("in");
            setTimeout(c.proxy(function () {
                this.popover.css("display", this.isInline() ? "" : "block");
                this._trigger("iconpickerShown", {
                    iconpickerValue: this.iconpickerValue
                });
            }, this), this.options.animation ? 300 : 1);
        },
        hide: function () {
            if (!this.popover.hasClass("in")) {
                return false;
            }
            this._trigger("iconpickerHide", {
                iconpickerValue: this.iconpickerValue
            });
            this.popover.removeClass("in");
            setTimeout(c.proxy(function () {
                this.popover.css("display", "none");
                this.getSearchInput().val("");
                this.filter("");
                this._trigger("iconpickerHidden", {
                    iconpickerValue: this.iconpickerValue
                });
            }, this), this.options.animation ? 300 : 1);
        },
        toggle: function () {
            if (this.popover.is(":visible")) {
                this.hide();
            } else {
                this.show(true);
            }
        },
        update: function (e, a) {
            e = e ? e : this.getSourceValue(this.iconpickerValue);
            this._trigger("iconpickerUpdate", {
                iconpickerValue: this.iconpickerValue
            });
            if (a === true) {
                e = this.setValue(e);
            } else {
                e = this.setSourceValue(e);
                this._updateFormGroupStatus(e !== false);
            }
            if (e !== false) {
                this._updateComponents();
            }
            this._trigger("iconpickerUpdated", {
                iconpickerValue: this.iconpickerValue
            });
            return e;
        },
        destroy: function () {
            this._trigger("iconpickerDestroy", {
                iconpickerValue: this.iconpickerValue
            });
            this.element.removeData("iconpicker").removeData("iconpickerValue").removeClass("iconpicker-element");
            this._unbindElementEvents();
            this._unbindWindowEvents();
            c(this.popover).remove();
            this._trigger("iconpickerDestroyed", {
                iconpickerValue: this.iconpickerValue
            });
        },
        disable: function () {
            if (this.hasInput()) {
                this.input.prop("disabled", true);
                return true;
            }
            return false;
        },
        enable: function () {
            if (this.hasInput()) {
                this.input.prop("disabled", false);
                return true;
            }
            return false;
        },
        isDisabled: function () {
            if (this.hasInput()) {
                return this.input.prop("disabled") === true;
            }
            return false;
        },
        isInline: function () {
            return this.options.placement === "inline" || this.popover.hasClass("inline");
        }
    };
    c.iconpicker = t;
    c.fn.iconpicker = function (a) {
        return this.each(function () {
            var e = c(this);
            if (!e.data("iconpicker")) {
                e.data("iconpicker", new t(this, typeof a === "object" ? a : {}));
            }
        });
    };
    t.defaultOptions = c.extend(t.defaultOptions, {
        icons: [{
            title: "bi bi-alarm",
            searchTerms: []
        }, {
            title: "bi bi-align-middle",
            searchTerms: ["middle", "text"]
        }, {
            title: "bi bi-align-center",
            searchTerms: ["text", "center"]
        }, {
            title: "bi bi-align-start",
            searchTerms: ["text"]
        }, {
            title: "bi bi-align-end",
            searchTerms: ["text"]
        }, {
            title: "bi bi-align-bottom",
            searchTerms: ["text", "bottom"]
        }, {
            title: "bi bi-align-top",
            searchTerms: ["text", "top"]
        }, {
            title: "bi bi-alt",
            searchTerms: []
        }, {
            title: "bi bi-app",
            searchTerms: []
        }, {
            title: "bi bi-app-indicator",
            searchTerms: []
        }, {
            title: "bi bi-archive",
            searchTerms: ["archive"]
        }, {
            title: "bi bi-archive-fill",
            searchTerms: ["archive"]
        }, {
            title: "bi bi-arrow-90deg-down",
            searchTerms: ["arrow"]
        }, {
            title: "bi bi-arrow-90deg-left",
            searchTerms: ["arrow", "left"]
        }, {
            title: "bi bi-arrow-90deg-right",
            searchTerms: ["arrow", "right"]
        }, {
            title: "bi bi-arrow-90deg-up",
            searchTerms: ["arrow", "up"]
        }, {
            title: "bi bi-arrow-bar-down",
            searchTerms: ["arrow", "down"]
        }, {
            title: "bi bi-arrow-bar-left",
            searchTerms: ["arrow", "left"]
        }, {
            title: "bi bi-arrow-bar-right",
            searchTerms: ["arrow", "right"]
        }, {
            title: "bi bi-arrow-bar-up",
            searchTerms: ["arrow", "up"]
        }, {
            title: "bi bi-arrow-bar-down",
            searchTerms: ["arrow", "down"]
        }, {
            title: "bi bi-arrow-clockwise",
            searchTerms: ["arrow"]
        }, {
            title: "bi bi-arrow-counterclockwise",
            searchTerms: ["arrow"]
        }, {
            title: "bi bi-arrow-down",
            searchTerms: ["arrow", "down"]
        }, {
            title: "bi bi-arrow-down-circle",
            searchTerms: ["arrow", "down", "circle"]
        }, {
            title: "bi bi-arrow-down-circle-fill",
            searchTerms: ["arrow", "circle", "fill"]
        }, {
            title: "bi bi-arrow-down-left-circle",
            searchTerms: []
        }, {
            title: "bi bi-arrow-down-left-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-arrow-down-left-square",
            searchTerms: []
        }, {
            title: "bi bi-arrow-down-left-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-arrow-down-right-circle",
            searchTerms: []
        }, {
            title: "bi bi-arrow-down-right-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-arrow-down-right-square",
            searchTerms: []
        }, {
            title: "bi bi-arrow-down-right-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-arrow-down-square",
            searchTerms: []
        }, {
            title: "bi bi-arrow-down-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-arrow-down-left",
            searchTerms: []
        }, {
            title: "bi bi-arrow-down-right",
            searchTerms: []
        }, {
            title: "bi bi-arrow-down-short",
            searchTerms: []
        }, {
            title: "bi bi-arrow-down-up",
            searchTerms: []
        }, {
            title: "bi bi-arrow-left",
            searchTerms: []
        }, {
            title: "bi bi-arrow-left-circle",
            searchTerms: []
        }, {
            title: "bi bi-arrow-left-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-arrow-left-square",
            searchTerms: []
        }, {
            title: "bi bi-arrow-left-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-arrow-left-right",
            searchTerms: []
        }, {
            title: "bi bi-arrow-left-short",
            searchTerms: []
        }, {
            title: "bi bi-arrow-repeat",
            searchTerms: []
        }, {
            title: "bi bi-arrow-return-left",
            searchTerms: []
        }, {
            title: "bi bi-arrow-return-right",
            searchTerms: []
        }, {
            title: "bi bi-arrow-right",
            searchTerms: []
        }, {
            title: "bi bi-arrow-right-circle",
            searchTerms: []
        }, {
            title: "bi bi-arrow-right-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-arrow-right-square",
            searchTerms: []
        }, {
            title: "bi bi-arrow-right-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-arrow-right-short",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up-circle",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up-left-circle",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up-left-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up-left-square",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up-left-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up-right-circle",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up-right-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up-right-square",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up-right-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up-square",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up-left",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up-right",
            searchTerms: []
        }, {
            title: "bi bi-arrow-up-short",
            searchTerms: []
        }, {
            title: "bi bi-arrows-angle-contract",
            searchTerms: []
        }, {
            title: "bi bi-arrows-angle-expand",
            searchTerms: []
        }, {
            title: "bi bi-arrows-collapse",
            searchTerms: []
        }, {
            title: "bi bi-arrows-expand",
            searchTerms: []
        }, {
            title: "bi bi-arrows-fullscreen",
            searchTerms: []
        }, {
            title: "bi bi-arrows-move",
            searchTerms: []
        }, {
            title: "bi bi-aspect-ratio",
            searchTerms: []
        }, {
            title: "bi bi-aspect-ratio-fill",
            searchTerms: []
        }, {
            title: "bi bi-asterisk",
            searchTerms: []
        }, {
            title: "bi bi-at",
            searchTerms: []
        }, {
            title: "bi bi-award",
            searchTerms: []
        }, {
            title: "bi bi-award-fill",
            searchTerms: []
        }, {
            title: "bi bi-back",
            searchTerms: []
        }, {
            title: "bi bi-backspace",
            searchTerms: []
        }, {
            title: "bi bi-backspace-fill",
            searchTerms: []
        }, {
            title: "bi bi-backspace-reverse",
            searchTerms: []
        }, {
            title: "bi bi-backspace-reverse-fill",
            searchTerms: []
        }, {
            title: "bi bi-badge-3d",
            searchTerms: []
        }, {
            title: "bi bi-badge-3d-fill",
            searchTerms: []
        }, {
            title: "bi bi-badge-4k",
            searchTerms: []
        }, {
            title: "bi bi-badge-4k-fill",
            searchTerms: []
        }, {
            title: "bi bi-badge-8k",
            searchTerms: []
        }, {
            title: "bi bi-badge-8k-fill",
            searchTerms: []
        }, {
            title: "bi bi-badge-ad",
            searchTerms: []
        }, {
            title: "bi bi-badge-ad-fill",
            searchTerms: []
        }, {
            title: "bi bi-badge-ar",
            searchTerms: []
        }, {
            title: "bi bi-badge-ar-fill",
            searchTerms: []
        }, {
            title: "bi bi-badge-cc",
            searchTerms: []
        }, {
            title: "bi bi-badge-cc-fill",
            searchTerms: []
        }, {
            title: "bi bi-badge-hd",
            searchTerms: []
        }, {
            title: "bi bi-badge-hd-fill",
            searchTerms: []
        }, {
            title: "bi bi-badge-tm",
            searchTerms: []
        }, {
            title: "bi bi-badge-tm-fill",
            searchTerms: []
        }, {
            title: "bi bi-badge-vo",
            searchTerms: []
        }, {
            title: "bi bi-badge-vo-fill",
            searchTerms: []
        }, {
            title: "bi bi-badge-vr",
            searchTerms: []
        }, {
            title: "bi bi-badge-vr-fill",
            searchTerms: []
        }, {
            title: "bi bi-badge-wc",
            searchTerms: []
        }, {
            title: "bi bi-badge-wc-fill",
            searchTerms: []
        }, {
            title: "bi bi-bag",
            searchTerms: []
        }, {
            title: "bi bi-bag-check",
            searchTerms: []
        }, {
            title: "bi bi-bag-check-fill",
            searchTerms: []
        }, {
            title: "bi bi-bag-dash",
            searchTerms: []
        }, {
            title: "bi bi-bag-dash-fill",
            searchTerms: []
        }, {
            title: "bi bi-bag-fill",
            searchTerms: []
        }, {
            title: "bi bi-bag-plus",
            searchTerms: []
        }, {
            title: "bi bi-bag-plus-fill",
            searchTerms: []
        }, {
            title: "bi bi-bag-x",
            searchTerms: []
        }, {
            title: "bi bi-bag-x-fill",
            searchTerms: []
        }, {
            title: "bi bi-bank",
            searchTerms: []
        }, {
            title: "bi bi-bank2",
            searchTerms: []
        }, {
            title: "bi bi-bar-chart",
            searchTerms: []
        }, {
            title: "bi bi-bar-chart-fill",
            searchTerms: []
        }, {
            title: "bi bi-bar-chart-line",
            searchTerms: []
        }, {
            title: "bi bi-bar-chart-line-fill",
            searchTerms: []
        }, {
            title: "bi bi-bar-chart-steps",
            searchTerms: []
        }, {
            title: "bi bi-basket",
            searchTerms: []
        }, {
            title: "bi bi-basket-fill",
            searchTerms: []
        }, {
            title: "bi bi-basket2",
            searchTerms: []
        }, {
            title: "bi bi-basket2-fill",
            searchTerms: []
        }, {
            title: "bi bi-basket3",
            searchTerms: []
        }, {
            title: "bi bi-basket3-fill",
            searchTerms: []
        }, {
            title: "bi bi-battery",
            searchTerms: []
        }, {
            title: "bi bi-battery-charging",
            searchTerms: []
        }, {
            title: "bi bi-battery-full",
            searchTerms: []
        }, {
            title: "bi bi-battery-half",
            searchTerms: []
        }, {
            title: "bi bi-bell",
            searchTerms: []
        }, {
            title: "bi bi-bell-fill",
            searchTerms: []
        }, {
            title: "bi bi-bell-slash",
            searchTerms: []
        }, {
            title: "bi bi-bell-slash-fill",
            searchTerms: []
        }, {
            title: "bi bi-bezier",
            searchTerms: []
        }, {
            title: "bi bi-bezier2",
            searchTerms: []
        }, {
            title: "bi bi-bicycle",
            searchTerms: []
        }, {
            title: "bi bi-binoculars",
            searchTerms: []
        }, {
            title: "bi bi-binoculars-fill",
            searchTerms: []
        }, {
            title: "bi bi-blockquote-left",
            searchTerms: []
        }, {
            title: "bi bi-blockquote-right",
            searchTerms: []
        }, {
            title: "bi bi-book",
            searchTerms: []
        }, {
            title: "bi bi-book-fill",
            searchTerms: []
        }, {
            title: "bi bi-book-half",
            searchTerms: []
        }, {
            title: "bi bi-bookmark",
            searchTerms: []
        }, {
            title: "bi bi-bookmark-check",
            searchTerms: []
        }, {
            title: "bi bi-bookmark-check-fill",
            searchTerms: []
        }, {
            title: "bi bi-bookmark-dash",
            searchTerms: []
        }, {
            title: "bi bi-bookmark-dash-fill",
            searchTerms: []
        }, {
            title: "bi bi-bookmark-fill",
            searchTerms: []
        }, {
            title: "bi bi-bookmark-heart",
            searchTerms: []
        }, {
            title: "bi bi-bookmark-heart-fill",
            searchTerms: []
        }, {
            title: "bi bi-bookmark-plus",
            searchTerms: []
        }, {
            title: "bi bi-bookmark-plus-fill",
            searchTerms: []
        }, {
            title: "bi bi-bookmark-star",
            searchTerms: []
        }, {
            title: "bi bi-bookmark-star-fill",
            searchTerms: []
        }, {
            title: "bi bi-bookmark-x",
            searchTerms: []
        }, {
            title: "bi bi-bookmark-x-fill",
            searchTerms: []
        }, {
            title: "bi bi-bookmarks",
            searchTerms: []
        }, {
            title: "bi bi-bookmarks-fill",
            searchTerms: []
        }, {
            title: "bi bi-bookshelf",
            searchTerms: []
        }, {
            title: "bi bi-bootstrap",
            searchTerms: []
        }, {
            title: "bi bi-bootstrap-fill",
            searchTerms: []
        }, {
            title: "bi bi-bootstrap-reboot",
            searchTerms: []
        }, {
            title: "bi bi-border",
            searchTerms: []
        }, {
            title: "bi bi-border-all",
            searchTerms: []
        }, {
            title: "bi bi-border-bottom",
            searchTerms: []
        }, {
            title: "bi bi-border-center",
            searchTerms: []
        }, {
            title: "bi bi-border-inner",
            searchTerms: []
        }, {
            title: "bi bi-border-left",
            searchTerms: []
        }, {
            title: "bi bi-border-middle",
            searchTerms: []
        }, {
            title: "bi bi-border-outer",
            searchTerms: []
        }, {
            title: "bi bi-border-right",
            searchTerms: []
        }, {
            title: "bi bi-border-style",
            searchTerms: []
        }, {
            title: "bi bi-border-top",
            searchTerms: []
        }, {
            title: "bi bi-border-width",
            searchTerms: []
        }, {
            title: "bi bi-bounding-box",
            searchTerms: []
        }, {
            title: "bi bi-bounding-box-circles",
            searchTerms: []
        }, {
            title: "bi bi-box",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-down-left",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-down-right",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-down",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-in-down",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-in-down-left",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-in-down-right",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-in-left",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-in-right",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-in-up",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-in-up-left",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-in-up-right",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-left",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-right",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-up",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-up-left",
            searchTerms: []
        }, {
            title: "bi bi-box-arrow-up-right",
            searchTerms: []
        }, {
            title: "bi bi-box-seam",
            searchTerms: []
        }, {
            title: "bi bi-braces",
            searchTerms: []
        }, {
            title: "bi bi-bricks",
            searchTerms: []
        }, {
            title: "bi bi-briefcase",
            searchTerms: []
        }, {
            title: "bi bi-briefcase-fill",
            searchTerms: []
        }, {
            title: "bi bi-brightness-alt-high",
            searchTerms: []
        }, {
            title: "bi bi-brightness-alt-high-fill",
            searchTerms: []
        }, {
            title: "bi bi-brightness-alt-low",
            searchTerms: []
        }, {
            title: "bi bi-brightness-alt-low-fill",
            searchTerms: []
        }, {
            title: "bi bi-brightness-high",
            searchTerms: []
        }, {
            title: "bi bi-brightness-high-fill",
            searchTerms: []
        }, {
            title: "bi bi-brightness-low",
            searchTerms: []
        }, {
            title: "bi bi-brightness-low-fill",
            searchTerms: []
        }, {
            title: "bi bi-broadcast",
            searchTerms: []
        }, {
            title: "bi bi-broadcast-pin",
            searchTerms: []
        }, {
            title: "bi bi-brush",
            searchTerms: []
        }, {
            title: "bi bi-brush-fill",
            searchTerms: []
        }, {
            title: "bi bi-bucket",
            searchTerms: []
        }, {
            title: "bi bi-bucket-fill",
            searchTerms: []
        }, {
            title: "bi bi-bug",
            searchTerms: []
        }, {
            title: "bi bi-bug-fill",
            searchTerms: []
        }, {
            title: "bi bi-building",
            searchTerms: []
        }, {
            title: "bi bi-bullseye",
            searchTerms: []
        }, {
            title: "bi bi-calculator",
            searchTerms: []
        }, {
            title: "bi bi-calculator-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar",
            searchTerms: []
        }, {
            title: "bi bi-calendar-check",
            searchTerms: []
        }, {
            title: "bi bi-calendar-check-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar-date",
            searchTerms: []
        }, {
            title: "bi bi-calendar-date-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar-day",
            searchTerms: []
        }, {
            title: "bi bi-calendar-day-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar-event",
            searchTerms: []
        }, {
            title: "bi bi-calendar-event-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar-minus",
            searchTerms: []
        }, {
            title: "bi bi-calendar-minus-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar-month",
            searchTerms: []
        }, {
            title: "bi bi-calendar-month-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar-plus",
            searchTerms: []
        }, {
            title: "bi bi-calendar-plus-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar-range",
            searchTerms: []
        }, {
            title: "bi bi-calendar-range-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar-week",
            searchTerms: []
        }, {
            title: "bi bi-calendar-week-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar-x",
            searchTerms: []
        }, {
            title: "bi bi-calendar-x-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar2",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-check",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-check-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-date",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-date-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-day",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-day-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-event",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-event-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-minus",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-minus-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-month",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-month-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-plus",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-plus-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-range",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-range-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-week",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-week-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-x",
            searchTerms: []
        }, {
            title: "bi bi-calendar2-x-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar3",
            searchTerms: []
        }, {
            title: "bi bi-calendar3-event",
            searchTerms: []
        }, {
            title: "bi bi-calendar3-event-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar3-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar3-range",
            searchTerms: []
        }, {
            title: "bi bi-calendar3-range-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar3-week",
            searchTerms: []
        }, {
            title: "bi bi-calendar3-week-fill",
            searchTerms: []
        }, {
            title: "bi bi-calendar4",
            searchTerms: []
        }, {
            title: "bi bi-calendar4-event",
            searchTerms: []
        }, {
            title: "bi bi-calendar4-range",
            searchTerms: []
        }, {
            title: "bi bi-calendar4-week",
            searchTerms: []
        }, {
            title: "bi bi-camera",
            searchTerms: []
        }, {
            title: "bi bi-camera2",
            searchTerms: []
        }, {
            title: "bi bi-camera-fill",
            searchTerms: []
        }, {
            title: "bi bi-camera-reels",
            searchTerms: []
        }, {
            title: "bi bi-camera-reels-fill",
            searchTerms: []
        }, {
            title: "bi bi-camera-video",
            searchTerms: []
        }, {
            title: "bi bi-camera-video-fill",
            searchTerms: []
        }, {
            title: "bi bi-camera-video-off",
            searchTerms: []
        }, {
            title: "bi bi-camera-video-off-fill",
            searchTerms: []
        }, {
            title: "bi bi-capslock",
            searchTerms: []
        }, {
            title: "bi bi-capslock-fill",
            searchTerms: []
        }, {
            title: "bi bi-card-checklist",
            searchTerms: []
        }, {
            title: "bi bi-card-heading",
            searchTerms: []
        }, {
            title: "bi bi-card-image",
            searchTerms: []
        }, {
            title: "bi bi-card-list",
            searchTerms: []
        }, {
            title: "bi bi-card-text",
            searchTerms: []
        }, {
            title: "bi bi-caret-down",
            searchTerms: []
        }, {
            title: "bi bi-caret-down-fill",
            searchTerms: []
        }, {
            title: "bi bi-caret-down-square",
            searchTerms: []
        }, {
            title: "bi bi-caret-down-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-caret-left",
            searchTerms: []
        }, {
            title: "bi bi-caret-left-fill",
            searchTerms: []
        }, {
            title: "bi bi-caret-left-square",
            searchTerms: []
        }, {
            title: "bi bi-caret-left-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-caret-right",
            searchTerms: []
        }, {
            title: "bi bi-caret-right-fill",
            searchTerms: []
        }, {
            title: "bi bi-caret-right-square",
            searchTerms: []
        }, {
            title: "bi bi-caret-right-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-caret-up",
            searchTerms: []
        }, {
            title: "bi bi-caret-up-fill",
            searchTerms: []
        }, {
            title: "bi bi-caret-up-square",
            searchTerms: []
        }, {
            title: "bi bi-caret-up-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-cart",
            searchTerms: []
        }, {
            title: "bi bi-cart-check",
            searchTerms: []
        }, {
            title: "bi bi-cart-check-fill",
            searchTerms: []
        }, {
            title: "bi bi-cart-dash",
            searchTerms: []
        }, {
            title: "bi bi-cart-dash-fill",
            searchTerms: []
        }, {
            title: "bi bi-cart-fill",
            searchTerms: []
        }, {
            title: "bi bi-cart-plus",
            searchTerms: []
        }, {
            title: "bi bi-cart-plus-fill",
            searchTerms: []
        }, {
            title: "bi bi-cart-x",
            searchTerms: []
        }, {
            title: "bi bi-cart-x-fill",
            searchTerms: []
        }, {
            title: "bi bi-cart2",
            searchTerms: []
        }, {
            title: "bi bi-cart3",
            searchTerms: []
        }, {
            title: "bi bi-cart4",
            searchTerms: []
        }, {
            title: "bi bi-cash",
            searchTerms: []
        }, {
            title: "bi bi-cash-coin",
            searchTerms: []
        }, {
            title: "bi bi-cash-stack",
            searchTerms: []
        }, {
            title: "bi bi-cast",
            searchTerms: []
        }, {
            title: "bi bi-chat",
            searchTerms: []
        }, {
            title: "bi bi-chat-dots",
            searchTerms: []
        }, {
            title: "bi bi-chat-dots-fill",
            searchTerms: []
        }, {
            title: "bi bi-chat-fill",
            searchTerms: []
        }, {
            title: "bi bi-chat-left",
            searchTerms: []
        }, {
            title: "bi bi-chat-left-dots",
            searchTerms: []
        }, {
            title: "bi bi-chat-left-dots-fill",
            searchTerms: []
        }, {
            title: "bi bi-chat-left-fill",
            searchTerms: []
        }, {
            title: "bi bi-chat-left-quote",
            searchTerms: []
        }, {
            title: "bi bi-chat-left-quote-fill",
            searchTerms: []
        }, {
            title: "bi bi-chat-left-text",
            searchTerms: []
        }, {
            title: "bi bi-chat-left-text-fill",
            searchTerms: []
        }, {
            title: "bi bi-chat-quote",
            searchTerms: []
        }, {
            title: "bi bi-chat-quote-fill",
            searchTerms: []
        }, {
            title: "bi bi-chat-right",
            searchTerms: []
        }, {
            title: "bi bi-chat-right-dots",
            searchTerms: []
        }, {
            title: "bi bi-chat-right-dots-fill",
            searchTerms: []
        }, {
            title: "bi bi-chat-right-fill",
            searchTerms: []
        }, {
            title: "bi bi-chat-right-quote",
            searchTerms: []
        }, {
            title: "bi bi-chat-right-quote-fill",
            searchTerms: []
        }, {
            title: "bi bi-chat-right-text",
            searchTerms: []
        }, {
            title: "bi bi-chat-right-text-fill",
            searchTerms: []
        }, {
            title: "bi bi-chat-square",
            searchTerms: []
        }, {
            title: "bi bi-chat-square-dots",
            searchTerms: []
        }, {
            title: "bi bi-chat-square-dots-fill",
            searchTerms: []
        }, {
            title: "bi bi-chat-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-chat-square-quote",
            searchTerms: []
        }, {
            title: "bi bi-chat-square-quote-fill",
            searchTerms: []
        }, {
            title: "bi bi-chat-square-text",
            searchTerms: []
        }, {
            title: "bi bi-chat-square-text-fill",
            searchTerms: []
        }, {
            title: "bi bi-chat-text",
            searchTerms: []
        }, {
            title: "bi bi-chat-text-fill",
            searchTerms: []
        }, {
            title: "bi bi-check",
            searchTerms: []
        }, {
            title: "bi bi-check-all",
            searchTerms: []
        }, {
            title: "bi bi-check-circle",
            searchTerms: []
        }, {
            title: "bi bi-check-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-check-lg",
            searchTerms: []
        }, {
            title: "bi bi-check-square",
            searchTerms: []
        }, {
            title: "bi bi-check-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-check2",
            searchTerms: []
        }, {
            title: "bi bi-check2-all",
            searchTerms: []
        }, {
            title: "bi bi-check2-circle",
            searchTerms: []
        }, {
            title: "bi bi-check2-square",
            searchTerms: []
        }, {
            title: "bi bi-chevron-bar-contract",
            searchTerms: []
        }, {
            title: "bi bi-chevron-bar-down",
            searchTerms: []
        }, {
            title: "bi bi-chevron-bar-expand",
            searchTerms: []
        }, {
            title: "bi bi-chevron-bar-left",
            searchTerms: []
        }, {
            title: "bi bi-chevron-bar-right",
            searchTerms: []
        }, {
            title: "bi bi-chevron-bar-up",
            searchTerms: []
        }, {
            title: "bi bi-chevron-compact-down",
            searchTerms: []
        }, {
            title: "bi bi-chevron-compact-left",
            searchTerms: []
        }, {
            title: "bi bi-chevron-compact-right",
            searchTerms: []
        }, {
            title: "bi bi-chevron-compact-up",
            searchTerms: []
        }, {
            title: "bi bi-chevron-contract",
            searchTerms: []
        }, {
            title: "bi bi-chevron-double-down",
            searchTerms: []
        }, {
            title: "bi bi-chevron-double-left",
            searchTerms: []
        }, {
            title: "bi bi-chevron-double-right",
            searchTerms: []
        }, {
            title: "bi bi-chevron-double-up",
            searchTerms: []
        }, {
            title: "bi bi-chevron-down",
            searchTerms: []
        }, {
            title: "bi bi-chevron-expand",
            searchTerms: []
        }, {
            title: "bi bi-chevron-left",
            searchTerms: []
        }, {
            title: "bi bi-chevron-right",
            searchTerms: []
        }, {
            title: "bi bi-chevron-up",
            searchTerms: []
        }, {
            title: "bi bi-circle",
            searchTerms: []
        }, {
            title: "bi bi-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-circle-half",
            searchTerms: []
        }, {
            title: "bi bi-slash-circle",
            searchTerms: []
        }, {
            title: "bi bi-circle-square",
            searchTerms: []
        }, {
            title: "bi bi-clipboard",
            searchTerms: []
        }, {
            title: "bi bi-clipboard-check",
            searchTerms: []
        }, {
            title: "bi bi-clipboard-data",
            searchTerms: []
        }, {
            title: "bi bi-clipboard-minus",
            searchTerms: []
        }, {
            title: "bi bi-clipboard-plus",
            searchTerms: []
        }, {
            title: "bi bi-clipboard-x",
            searchTerms: []
        }, {
            title: "bi bi-clock",
            searchTerms: []
        }, {
            title: "bi bi-clock-fill",
            searchTerms: []
        }, {
            title: "bi bi-clock-history",
            searchTerms: []
        }, {
            title: "bi bi-cloud",
            searchTerms: []
        }, {
            title: "bi bi-cloud-arrow-down",
            searchTerms: []
        }, {
            title: "bi bi-cloud-arrow-down-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-arrow-up",
            searchTerms: []
        }, {
            title: "bi bi-cloud-arrow-up-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-check",
            searchTerms: []
        }, {
            title: "bi bi-cloud-check-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-download",
            searchTerms: []
        }, {
            title: "bi bi-cloud-download-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-drizzle",
            searchTerms: []
        }, {
            title: "bi bi-cloud-drizzle-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-fog",
            searchTerms: []
        }, {
            title: "bi bi-cloud-fog-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-fog2",
            searchTerms: []
        }, {
            title: "bi bi-cloud-fog2-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-hail",
            searchTerms: []
        }, {
            title: "bi bi-cloud-hail-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-haze",
            searchTerms: []
        }, {
            title: "bi bi-cloud-haze-1",
            searchTerms: []
        }, {
            title: "bi bi-cloud-haze-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-haze2-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-lightning",
            searchTerms: []
        }, {
            title: "bi bi-cloud-lightning-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-lightning-rain",
            searchTerms: []
        }, {
            title: "bi bi-cloud-lightning-rain-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-minus",
            searchTerms: []
        }, {
            title: "bi bi-cloud-minus-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-moon",
            searchTerms: []
        }, {
            title: "bi bi-cloud-moon-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-plus",
            searchTerms: []
        }, {
            title: "bi bi-cloud-plus-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-rain",
            searchTerms: []
        }, {
            title: "bi bi-cloud-rain-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-rain-heavy",
            searchTerms: []
        }, {
            title: "bi bi-cloud-rain-heavy-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-slash",
            searchTerms: []
        }, {
            title: "bi bi-cloud-slash-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-sleet",
            searchTerms: []
        }, {
            title: "bi bi-cloud-sleet-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-snow",
            searchTerms: []
        }, {
            title: "bi bi-cloud-snow-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-sun",
            searchTerms: []
        }, {
            title: "bi bi-cloud-sun-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloud-upload",
            searchTerms: []
        }, {
            title: "bi bi-cloud-upload-fill",
            searchTerms: []
        }, {
            title: "bi bi-clouds",
            searchTerms: []
        }, {
            title: "bi bi-clouds-fill",
            searchTerms: []
        }, {
            title: "bi bi-cloudy",
            searchTerms: []
        }, {
            title: "bi bi-cloudy-fill",
            searchTerms: []
        }, {
            title: "bi bi-code",
            searchTerms: []
        }, {
            title: "bi bi-code-slash",
            searchTerms: []
        }, {
            title: "bi bi-code-square",
            searchTerms: []
        }, {
            title: "bi bi-coin",
            searchTerms: []
        }, {
            title: "bi bi-collection",
            searchTerms: []
        }, {
            title: "bi bi-collection-fill",
            searchTerms: []
        }, {
            title: "bi bi-collection-play",
            searchTerms: []
        }, {
            title: "bi bi-collection-play-fill",
            searchTerms: []
        }, {
            title: "bi bi-columns",
            searchTerms: []
        }, {
            title: "bi bi-columns-gap",
            searchTerms: []
        }, {
            title: "bi bi-command",
            searchTerms: []
        }, {
            title: "bi bi-compass",
            searchTerms: []
        }, {
            title: "bi bi-compass-fill",
            searchTerms: []
        }, {
            title: "bi bi-cone",
            searchTerms: []
        }, {
            title: "bi bi-cone-striped",
            searchTerms: []
        }, {
            title: "bi bi-controller",
            searchTerms: []
        }, {
            title: "bi bi-cpu",
            searchTerms: []
        }, {
            title: "bi bi-cpu-fill",
            searchTerms: []
        }, {
            title: "bi bi-credit-card",
            searchTerms: []
        }, {
            title: "bi bi-credit-card-2-back",
            searchTerms: []
        }, {
            title: "bi bi-credit-card-2-back-fill",
            searchTerms: []
        }, {
            title: "bi bi-credit-card-2-front",
            searchTerms: []
        }, {
            title: "bi bi-credit-card-2-front-fill",
            searchTerms: []
        }, {
            title: "bi bi-credit-card-fill",
            searchTerms: []
        }, {
            title: "bi bi-crop",
            searchTerms: []
        }, {
            title: "bi bi-cup",
            searchTerms: []
        }, {
            title: "bi bi-cup-fill",
            searchTerms: []
        }, {
            title: "bi bi-cup-straw",
            searchTerms: []
        }, {
            title: "bi bi-currency-bitcoin",
            searchTerms: []
        }, {
            title: "bi bi-currency-dollar",
            searchTerms: []
        }, {
            title: "bi bi-currency-euro",
            searchTerms: []
        }, {
            title: "bi bi-currency-exchange",
            searchTerms: []
        }, {
            title: "bi bi-currency-pound",
            searchTerms: []
        }, {
            title: "bi bi-currency-yen",
            searchTerms: []
        }, {
            title: "bi bi-cursor",
            searchTerms: []
        }, {
            title: "bi bi-cursor-fill",
            searchTerms: []
        }, {
            title: "bi bi-cursor-text",
            searchTerms: []
        }, {
            title: "bi bi-dash",
            searchTerms: []
        }, {
            title: "bi bi-dash-circle",
            searchTerms: []
        }, {
            title: "bi bi-dash-circle-dotted",
            searchTerms: []
        }, {
            title: "bi bi-dash-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-dash-lg",
            searchTerms: []
        }, {
            title: "bi bi-dash-square",
            searchTerms: []
        }, {
            title: "bi bi-dash-square-dotted",
            searchTerms: []
        }, {
            title: "bi bi-dash-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-diagram-2",
            searchTerms: []
        }, {
            title: "bi bi-diagram-2-fill",
            searchTerms: []
        }, {
            title: "bi bi-diagram-3",
            searchTerms: []
        }, {
            title: "bi bi-diagram-3-fill",
            searchTerms: []
        }, {
            title: "bi bi-diamond",
            searchTerms: []
        }, {
            title: "bi bi-diamond-fill",
            searchTerms: []
        }, {
            title: "bi bi-diamond-half",
            searchTerms: []
        }, {
            title: "bi bi-dice-1",
            searchTerms: []
        }, {
            title: "bi bi-dice-1-fill",
            searchTerms: []
        }, {
            title: "bi bi-dice-2",
            searchTerms: []
        }, {
            title: "bi bi-dice-2-fill",
            searchTerms: []
        }, {
            title: "bi bi-dice-3",
            searchTerms: []
        }, {
            title: "bi bi-dice-3-fill",
            searchTerms: []
        }, {
            title: "bi bi-dice-4",
            searchTerms: []
        }, {
            title: "bi bi-dice-4-fill",
            searchTerms: []
        }, {
            title: "bi bi-dice-5",
            searchTerms: []
        }, {
            title: "bi bi-dice-5-fill",
            searchTerms: []
        }, {
            title: "bi bi-dice-6",
            searchTerms: []
        }, {
            title: "bi bi-dice-6-fill",
            searchTerms: []
        }, {
            title: "bi bi-disc",
            searchTerms: []
        }, {
            title: "bi bi-disc-fill",
            searchTerms: []
        }, {
            title: "bi bi-discord",
            searchTerms: []
        }, {
            title: "bi bi-display",
            searchTerms: []
        }, {
            title: "bi bi-display-fill",
            searchTerms: []
        }, {
            title: "bi bi-distribute-horizontal",
            searchTerms: []
        }, {
            title: "bi bi-distribute-vertical",
            searchTerms: []
        }, {
            title: "bi bi-door-closed",
            searchTerms: []
        }, {
            title: "bi bi-door-closed-fill",
            searchTerms: []
        }, {
            title: "bi bi-door-open",
            searchTerms: []
        }, {
            title: "bi bi-door-open-fill",
            searchTerms: []
        }, {
            title: "bi bi-dot",
            searchTerms: []
        }, {
            title: "bi bi-download",
            searchTerms: []
        }, {
            title: "bi bi-droplet",
            searchTerms: []
        }, {
            title: "bi bi-droplet-fill",
            searchTerms: []
        }, {
            title: "bi bi-droplet-half",
            searchTerms: []
        }, {
            title: "bi bi-earbuds",
            searchTerms: []
        }, {
            title: "bi bi-easel",
            searchTerms: []
        }, {
            title: "bi bi-easel-fill",
            searchTerms: []
        }, {
            title: "bi bi-egg",
            searchTerms: []
        }, {
            title: "bi bi-egg-fill",
            searchTerms: []
        }, {
            title: "bi bi-egg-fried",
            searchTerms: []
        }, {
            title: "bi bi-eject",
            searchTerms: []
        }, {
            title: "bi bi-eject-fill",
            searchTerms: []
        }, {
            title: "bi bi-emoji-angry",
            searchTerms: []
        }, {
            title: "bi bi-emoji-angry-fill",
            searchTerms: []
        }, {
            title: "bi bi-emoji-dizzy",
            searchTerms: []
        }, {
            title: "bi bi-emoji-dizzy-fill",
            searchTerms: []
        }, {
            title: "bi bi-emoji-expressionless",
            searchTerms: []
        }, {
            title: "bi bi-emoji-expressionless-fill",
            searchTerms: []
        }, {
            title: "bi bi-emoji-frown",
            searchTerms: []
        }, {
            title: "bi bi-emoji-frown-fill",
            searchTerms: []
        }, {
            title: "bi bi-emoji-heart-eyes",
            searchTerms: []
        }, {
            title: "bi bi-emoji-heart-eyes-fill",
            searchTerms: []
        }, {
            title: "bi bi-emoji-laughing",
            searchTerms: []
        }, {
            title: "bi bi-emoji-laughing-fill",
            searchTerms: []
        }, {
            title: "bi bi-emoji-neutral",
            searchTerms: []
        }, {
            title: "bi bi-emoji-neutral-fill",
            searchTerms: []
        }, {
            title: "bi bi-emoji-smile",
            searchTerms: []
        }, {
            title: "bi bi-emoji-smile-fill",
            searchTerms: []
        }, {
            title: "bi bi-emoji-smile-upside-down",
            searchTerms: []
        }, {
            title: "bi bi-emoji-smile-upside-down-fill",
            searchTerms: []
        }, {
            title: "bi bi-emoji-sunglasses",
            searchTerms: []
        }, {
            title: "bi bi-emoji-sunglasses-fill",
            searchTerms: []
        }, {
            title: "bi bi-emoji-wink",
            searchTerms: []
        }, {
            title: "bi bi-emoji-wink-fill",
            searchTerms: []
        }, {
            title: "bi bi-envelope",
            searchTerms: []
        }, {
            title: "bi bi-envelope-fill",
            searchTerms: []
        }, {
            title: "bi bi-envelope-open",
            searchTerms: []
        }, {
            title: "bi bi-envelope-open-fill",
            searchTerms: []
        }, {
            title: "bi bi-eraser",
            searchTerms: []
        }, {
            title: "bi bi-eraser-fill",
            searchTerms: []
        }, {
            title: "bi bi-exclamation",
            searchTerms: []
        }, {
            title: "bi bi-exclamation-circle",
            searchTerms: []
        }, {
            title: "bi bi-exclamation-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-exclamation-diamond",
            searchTerms: []
        }, {
            title: "bi bi-exclamation-diamond-fill",
            searchTerms: []
        }, {
            title: "bi bi-exclamation-lg",
            searchTerms: []
        }, {
            title: "bi bi-exclamation-octagon",
            searchTerms: []
        }, {
            title: "bi bi-exclamation-octagon-fill",
            searchTerms: []
        }, {
            title: "bi bi-exclamation-square",
            searchTerms: []
        }, {
            title: "bi bi-exclamation-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-exclamation-triangle",
            searchTerms: []
        }, {
            title: "bi bi-exclamation-triangle-fill",
            searchTerms: []
        }, {
            title: "bi bi-exclude",
            searchTerms: []
        }, {
            title: "bi bi-eye",
            searchTerms: []
        }, {
            title: "bi bi-eye-fill",
            searchTerms: []
        }, {
            title: "bi bi-eye-slash",
            searchTerms: []
        }, {
            title: "bi bi-eye-slash-fill",
            searchTerms: []
        }, {
            title: "bi bi-eyedropper",
            searchTerms: []
        }, {
            title: "bi bi-eyeglasses",
            searchTerms: []
        }, {
            title: "bi bi-facebook",
            searchTerms: []
        }, {
            title: "bi bi-file",
            searchTerms: []
        }, {
            title: "bi bi-file-arrow-down",
            searchTerms: []
        }, {
            title: "bi bi-file-arrow-down-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-arrow-up",
            searchTerms: []
        }, {
            title: "bi bi-file-arrow-up-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-bar-graph",
            searchTerms: []
        }, {
            title: "bi bi-file-bar-graph-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-binary",
            searchTerms: []
        }, {
            title: "bi bi-file-binary-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-break",
            searchTerms: []
        }, {
            title: "bi bi-file-break-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-check",
            searchTerms: []
        }, {
            title: "bi bi-file-check-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-code",
            searchTerms: []
        }, {
            title: "bi bi-file-code-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-diff",
            searchTerms: []
        }, {
            title: "bi bi-file-diff-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-arrow-down",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-arrow-down-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-arrow-up",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-arrow-up-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-bar-graph",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-bar-graph-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-binary",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-binary-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-break",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-break-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-check",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-check-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-code",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-code-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-diff",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-diff-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-easel",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-easel-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-excel",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-excel-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-font",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-font-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-image",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-image-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-lock",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-lock-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-lock2",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-lock2-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-medical",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-medical-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-minus",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-minus-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-music",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-music-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-pdf",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-pdf-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-person",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-person-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-play",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-play-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-plus",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-plus-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-post",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-post-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-ppt",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-ppt-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-richtext",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-richtext-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-ruled",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-ruled-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-slides",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-slides-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-spreadsheet",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-spreadsheet-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-text",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-text-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-word",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-word-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-x",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-x-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-zip",
            searchTerms: []
        }, {
            title: "bi bi-file-earmark-zip-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-easel",
            searchTerms: []
        }, {
            title: "bi bi-file-easel-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-excel",
            searchTerms: []
        }, {
            title: "bi bi-file-excel-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-font",
            searchTerms: []
        }, {
            title: "bi bi-file-font-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-image",
            searchTerms: []
        }, {
            title: "bi bi-file-image-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-lock",
            searchTerms: []
        }, {
            title: "bi bi-file-lock-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-lock2",
            searchTerms: []
        }, {
            title: "bi bi-file-lock2-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-medical",
            searchTerms: []
        }, {
            title: "bi bi-file-medical-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-minus",
            searchTerms: []
        }, {
            title: "bi bi-file-minus-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-music",
            searchTerms: []
        }, {
            title: "bi bi-file-music-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-pdf",
            searchTerms: []
        }, {
            title: "bi bi-file-pdf-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-person",
            searchTerms: []
        }, {
            title: "bi bi-file-person-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-play",
            searchTerms: []
        }, {
            title: "bi bi-file-play-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-plus",
            searchTerms: []
        }, {
            title: "bi bi-file-plus-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-post",
            searchTerms: []
        }, {
            title: "bi bi-file-post-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-ppt",
            searchTerms: []
        }, {
            title: "bi bi-file-ppt-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-richtext",
            searchTerms: []
        }, {
            title: "bi bi-file-richtext-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-ruled",
            searchTerms: []
        }, {
            title: "bi bi-file-ruled-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-slides",
            searchTerms: []
        }, {
            title: "bi bi-file-slides-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-spreadsheet",
            searchTerms: []
        }, {
            title: "bi bi-file-spreadsheet-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-text",
            searchTerms: []
        }, {
            title: "bi bi-file-text-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-word",
            searchTerms: []
        }, {
            title: "bi bi-file-word-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-x",
            searchTerms: []
        }, {
            title: "bi bi-file-x-fill",
            searchTerms: []
        }, {
            title: "bi bi-file-zip",
            searchTerms: []
        }, {
            title: "bi bi-file-zip-fill",
            searchTerms: []
        }, {
            title: "bi bi-files",
            searchTerms: []
        }, {
            title: "bi bi-files-alt",
            searchTerms: []
        }, {
            title: "bi bi-film",
            searchTerms: []
        }, {
            title: "bi bi-filter",
            searchTerms: []
        }, {
            title: "bi bi-filter-circle",
            searchTerms: []
        }, {
            title: "bi bi-filter-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-filter-left",
            searchTerms: []
        }, {
            title: "bi bi-filter-right",
            searchTerms: []
        }, {
            title: "bi bi-filter-square",
            searchTerms: []
        }, {
            title: "bi bi-filter-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-flag",
            searchTerms: []
        }, {
            title: "bi bi-flag-fill",
            searchTerms: []
        }, {
            title: "bi bi-flower1",
            searchTerms: []
        }, {
            title: "bi bi-flower2",
            searchTerms: []
        }, {
            title: "bi bi-flower3",
            searchTerms: []
        }, {
            title: "bi bi-folder",
            searchTerms: []
        }, {
            title: "bi bi-folder-check",
            searchTerms: []
        }, {
            title: "bi bi-folder-fill",
            searchTerms: []
        }, {
            title: "bi bi-folder-minus",
            searchTerms: []
        }, {
            title: "bi bi-folder-plus",
            searchTerms: []
        }, {
            title: "bi bi-folder-symlink",
            searchTerms: []
        }, {
            title: "bi bi-folder-symlink-fill",
            searchTerms: []
        }, {
            title: "bi bi-folder-x",
            searchTerms: []
        }, {
            title: "bi bi-folder2",
            searchTerms: []
        }, {
            title: "bi bi-folder2-open",
            searchTerms: []
        }, {
            title: "bi bi-fonts",
            searchTerms: []
        }, {
            title: "bi bi-forward",
            searchTerms: []
        }, {
            title: "bi bi-forward-fill",
            searchTerms: []
        }, {
            title: "bi bi-front",
            searchTerms: []
        }, {
            title: "bi bi-fullscreen",
            searchTerms: []
        }, {
            title: "bi bi-fullscreen-exit",
            searchTerms: []
        }, {
            title: "bi bi-funnel",
            searchTerms: []
        }, {
            title: "bi bi-funnel-fill",
            searchTerms: []
        }, {
            title: "bi bi-gear",
            searchTerms: []
        }, {
            title: "bi bi-gear-fill",
            searchTerms: []
        }, {
            title: "bi bi-gear-wide",
            searchTerms: []
        }, {
            title: "bi bi-gear-wide-connected",
            searchTerms: []
        }, {
            title: "bi bi-gem",
            searchTerms: []
        }, {
            title: "bi bi-gender-ambiguous",
            searchTerms: []
        }, {
            title: "bi bi-gender-female",
            searchTerms: []
        }, {
            title: "bi bi-gender-male",
            searchTerms: []
        }, {
            title: "bi bi-gender-trans",
            searchTerms: []
        }, {
            title: "bi bi-geo",
            searchTerms: []
        }, {
            title: "bi bi-geo-alt",
            searchTerms: []
        }, {
            title: "bi bi-geo-alt-fill",
            searchTerms: []
        }, {
            title: "bi bi-geo-fill",
            searchTerms: []
        }, {
            title: "bi bi-gift",
            searchTerms: []
        }, {
            title: "bi bi-gift-fill",
            searchTerms: []
        }, {
            title: "bi bi-github",
            searchTerms: []
        }, {
            title: "bi bi-globe",
            searchTerms: []
        }, {
            title: "bi bi-globe2",
            searchTerms: []
        }, {
            title: "bi bi-google",
            searchTerms: []
        }, {
            title: "bi bi-graph-down",
            searchTerms: []
        }, {
            title: "bi bi-graph-up",
            searchTerms: []
        }, {
            title: "bi bi-grid",
            searchTerms: []
        }, {
            title: "bi bi-grid-1x2",
            searchTerms: []
        }, {
            title: "bi bi-grid-1x2-fill",
            searchTerms: []
        }, {
            title: "bi bi-grid-3x2",
            searchTerms: []
        }, {
            title: "bi bi-grid-3x2-gap",
            searchTerms: []
        }, {
            title: "bi bi-grid-3x2-gap-fill",
            searchTerms: []
        }, {
            title: "bi bi-grid-3x3",
            searchTerms: []
        }, {
            title: "bi bi-grid-3x3-gap",
            searchTerms: []
        }, {
            title: "bi bi-grid-3x3-gap-fill",
            searchTerms: []
        }, {
            title: "bi bi-grid-fill",
            searchTerms: []
        }, {
            title: "bi bi-grip-horizontal",
            searchTerms: []
        }, {
            title: "bi bi-grip-vertical",
            searchTerms: []
        }, {
            title: "bi bi-hammer",
            searchTerms: []
        }, {
            title: "bi bi-hand-index",
            searchTerms: []
        }, {
            title: "bi bi-hand-index-fill",
            searchTerms: []
        }, {
            title: "bi bi-hand-index-thumb",
            searchTerms: []
        }, {
            title: "bi bi-hand-index-thumb-fill",
            searchTerms: []
        }, {
            title: "bi bi-hand-thumbs-down",
            searchTerms: []
        }, {
            title: "bi bi-hand-thumbs-down-fill",
            searchTerms: []
        }, {
            title: "bi bi-hand-thumbs-up",
            searchTerms: []
        }, {
            title: "bi bi-hand-thumbs-up-fill",
            searchTerms: []
        }, {
            title: "bi bi-handbag",
            searchTerms: []
        }, {
            title: "bi bi-handbag-fill",
            searchTerms: []
        }, {
            title: "bi bi-hash",
            searchTerms: []
        }, {
            title: "bi bi-hdd",
            searchTerms: []
        }, {
            title: "bi bi-hdd-fill",
            searchTerms: []
        }, {
            title: "bi bi-hdd-network",
            searchTerms: []
        }, {
            title: "bi bi-hdd-network-fill",
            searchTerms: []
        }, {
            title: "bi bi-hdd-rack",
            searchTerms: []
        }, {
            title: "bi bi-hdd-rack-fill",
            searchTerms: []
        }, {
            title: "bi bi-hdd-stack",
            searchTerms: []
        }, {
            title: "bi bi-hdd-stack-fill",
            searchTerms: []
        }, {
            title: "bi bi-headphones",
            searchTerms: []
        }, {
            title: "bi bi-headset",
            searchTerms: []
        }, {
            title: "bi bi-headset-vr",
            searchTerms: []
        }, {
            title: "bi bi-heart",
            searchTerms: []
        }, {
            title: "bi bi-heart-fill",
            searchTerms: []
        }, {
            title: "bi bi-heart-half",
            searchTerms: []
        }, {
            title: "bi bi-heptagon",
            searchTerms: []
        }, {
            title: "bi bi-heptagon-fill",
            searchTerms: []
        }, {
            title: "bi bi-heptagon-half",
            searchTerms: []
        }, {
            title: "bi bi-hexagon",
            searchTerms: []
        }, {
            title: "bi bi-hexagon-fill",
            searchTerms: []
        }, {
            title: "bi bi-hexagon-half",
            searchTerms: []
        }, {
            title: "bi bi-hourglass",
            searchTerms: []
        }, {
            title: "bi bi-hourglass-bottom",
            searchTerms: []
        }, {
            title: "bi bi-hourglass-split",
            searchTerms: []
        }, {
            title: "bi bi-hourglass-top",
            searchTerms: []
        }, {
            title: "bi bi-house",
            searchTerms: []
        }, {
            title: "bi bi-house-door",
            searchTerms: []
        }, {
            title: "bi bi-house-door-fill",
            searchTerms: []
        }, {
            title: "bi bi-house-fill",
            searchTerms: []
        }, {
            title: "bi bi-hr",
            searchTerms: []
        }, {
            title: "bi bi-hurricane",
            searchTerms: []
        }, {
            title: "bi bi-image",
            searchTerms: []
        }, {
            title: "bi bi-image-alt",
            searchTerms: []
        }, {
            title: "bi bi-image-fill",
            searchTerms: []
        }, {
            title: "bi bi-images",
            searchTerms: []
        }, {
            title: "bi bi-inbox",
            searchTerms: []
        }, {
            title: "bi bi-inbox-fill",
            searchTerms: []
        }, {
            title: "bi bi-inboxes-fill",
            searchTerms: []
        }, {
            title: "bi bi-inboxes",
            searchTerms: []
        }, {
            title: "bi bi-info",
            searchTerms: []
        }, {
            title: "bi bi-info-circle",
            searchTerms: []
        }, {
            title: "bi bi-info-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-info-lg",
            searchTerms: []
        }, {
            title: "bi bi-info-square",
            searchTerms: []
        }, {
            title: "bi bi-info-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-input-cursor",
            searchTerms: []
        }, {
            title: "bi bi-input-cursor-text",
            searchTerms: []
        }, {
            title: "bi bi-instagram",
            searchTerms: []
        }, {
            title: "bi bi-intersect",
            searchTerms: []
        }, {
            title: "bi bi-journal",
            searchTerms: []
        }, {
            title: "bi bi-journal-album",
            searchTerms: []
        }, {
            title: "bi bi-journal-arrow-down",
            searchTerms: []
        }, {
            title: "bi bi-journal-arrow-up",
            searchTerms: []
        }, {
            title: "bi bi-journal-bookmark",
            searchTerms: []
        }, {
            title: "bi bi-journal-bookmark-fill",
            searchTerms: []
        }, {
            title: "bi bi-journal-check",
            searchTerms: []
        }, {
            title: "bi bi-journal-code",
            searchTerms: []
        }, {
            title: "bi bi-journal-medical",
            searchTerms: []
        }, {
            title: "bi bi-journal-minus",
            searchTerms: []
        }, {
            title: "bi bi-journal-plus",
            searchTerms: []
        }, {
            title: "bi bi-journal-richtext",
            searchTerms: []
        }, {
            title: "bi bi-journal-text",
            searchTerms: []
        }, {
            title: "bi bi-journal-x",
            searchTerms: []
        }, {
            title: "bi bi-journals",
            searchTerms: []
        }, {
            title: "bi bi-joystick",
            searchTerms: []
        }, {
            title: "bi bi-justify",
            searchTerms: []
        }, {
            title: "bi bi-justify-left",
            searchTerms: []
        }, {
            title: "bi bi-justify-right",
            searchTerms: []
        }, {
            title: "bi bi-kanban",
            searchTerms: []
        }, {
            title: "bi bi-kanban-fill",
            searchTerms: []
        }, {
            title: "bi bi-key",
            searchTerms: []
        }, {
            title: "bi bi-key-fill",
            searchTerms: []
        }, {
            title: "bi bi-keyboard",
            searchTerms: []
        }, {
            title: "bi bi-keyboard-fill",
            searchTerms: []
        }, {
            title: "bi bi-ladder",
            searchTerms: []
        }, {
            title: "bi bi-lamp",
            searchTerms: []
        }, {
            title: "bi bi-lamp-fill",
            searchTerms: []
        }, {
            title: "bi bi-laptop",
            searchTerms: []
        }, {
            title: "bi bi-laptop-fill",
            searchTerms: []
        }, {
            title: "bi bi-layer-backward",
            searchTerms: []
        }, {
            title: "bi bi-layer-forward",
            searchTerms: []
        }, {
            title: "bi bi-layers",
            searchTerms: []
        }, {
            title: "bi bi-layers-fill",
            searchTerms: []
        }, {
            title: "bi bi-layers-half",
            searchTerms: []
        }, {
            title: "bi bi-layout-sidebar",
            searchTerms: []
        }, {
            title: "bi bi-layout-sidebar-inset-reverse",
            searchTerms: []
        }, {
            title: "bi bi-layout-sidebar-inset",
            searchTerms: []
        }, {
            title: "bi bi-layout-sidebar-reverse",
            searchTerms: []
        }, {
            title: "bi bi-layout-split",
            searchTerms: []
        }, {
            title: "bi bi-layout-text-sidebar",
            searchTerms: []
        }, {
            title: "bi bi-layout-text-sidebar-reverse",
            searchTerms: []
        }, {
            title: "bi bi-layout-text-window",
            searchTerms: []
        }, {
            title: "bi bi-layout-text-window-reverse",
            searchTerms: []
        }, {
            title: "bi bi-layout-three-columns",
            searchTerms: []
        }, {
            title: "bi bi-layout-wtf",
            searchTerms: []
        }, {
            title: "bi bi-life-preserver",
            searchTerms: []
        }, {
            title: "bi bi-lightbulb",
            searchTerms: []
        }, {
            title: "bi bi-lightbulb-fill",
            searchTerms: []
        }, {
            title: "bi bi-lightbulb-off",
            searchTerms: []
        }, {
            title: "bi bi-lightbulb-off-fill",
            searchTerms: []
        }, {
            title: "bi bi-lightning",
            searchTerms: []
        }, {
            title: "bi bi-lightning-charge",
            searchTerms: []
        }, {
            title: "bi bi-lightning-charge-fill",
            searchTerms: []
        }, {
            title: "bi bi-lightning-fill",
            searchTerms: []
        }, {
            title: "bi bi-link",
            searchTerms: []
        }, {
            title: "bi bi-link-45deg",
            searchTerms: []
        }, {
            title: "bi bi-linkedin",
            searchTerms: []
        }, {
            title: "bi bi-list",
            searchTerms: []
        }, {
            title: "bi bi-list-check",
            searchTerms: []
        }, {
            title: "bi bi-list-nested",
            searchTerms: []
        }, {
            title: "bi bi-list-ol",
            searchTerms: []
        }, {
            title: "bi bi-list-stars",
            searchTerms: []
        }, {
            title: "bi bi-list-task",
            searchTerms: []
        }, {
            title: "bi bi-list-ul",
            searchTerms: []
        }, {
            title: "bi bi-lock",
            searchTerms: []
        }, {
            title: "bi bi-lock-fill",
            searchTerms: []
        }, {
            title: "bi bi-mailbox",
            searchTerms: []
        }, {
            title: "bi bi-mailbox2",
            searchTerms: []
        }, {
            title: "bi bi-map",
            searchTerms: []
        }, {
            title: "bi bi-map-fill",
            searchTerms: []
        }, {
            title: "bi bi-markdown",
            searchTerms: []
        }, {
            title: "bi bi-markdown-fill",
            searchTerms: []
        }, {
            title: "bi bi-mask",
            searchTerms: []
        }, {
            title: "bi bi-mastodon",
            searchTerms: []
        }, {
            title: "bi bi-megaphone",
            searchTerms: []
        }, {
            title: "bi bi-megaphone-fill",
            searchTerms: []
        }, {
            title: "bi bi-menu-app",
            searchTerms: []
        }, {
            title: "bi bi-menu-app-fill",
            searchTerms: []
        }, {
            title: "bi bi-menu-button",
            searchTerms: []
        }, {
            title: "bi bi-menu-button-fill",
            searchTerms: []
        }, {
            title: "bi bi-menu-button-wide",
            searchTerms: []
        }, {
            title: "bi bi-menu-button-wide-fill",
            searchTerms: []
        }, {
            title: "bi bi-menu-down",
            searchTerms: []
        }, {
            title: "bi bi-menu-up",
            searchTerms: []
        }, {
            title: "bi bi-messenger",
            searchTerms: []
        }, {
            title: "bi bi-mic",
            searchTerms: []
        }, {
            title: "bi bi-mic-fill",
            searchTerms: []
        }, {
            title: "bi bi-mic-mute",
            searchTerms: []
        }, {
            title: "bi bi-mic-mute-fill",
            searchTerms: []
        }, {
            title: "bi bi-minecart",
            searchTerms: []
        }, {
            title: "bi bi-minecart-loaded",
            searchTerms: []
        }, {
            title: "bi bi-moisture",
            searchTerms: []
        }, {
            title: "bi bi-moon",
            searchTerms: []
        }, {
            title: "bi bi-moon-fill",
            searchTerms: []
        }, {
            title: "bi bi-moon-stars",
            searchTerms: []
        }, {
            title: "bi bi-moon-stars-fill",
            searchTerms: []
        }, {
            title: "bi bi-mouse",
            searchTerms: []
        }, {
            title: "bi bi-mouse-fill",
            searchTerms: []
        }, {
            title: "bi bi-mouse2",
            searchTerms: []
        }, {
            title: "bi bi-mouse2-fill",
            searchTerms: []
        }, {
            title: "bi bi-mouse3",
            searchTerms: []
        }, {
            title: "bi bi-mouse3-fill",
            searchTerms: []
        }, {
            title: "bi bi-music-note",
            searchTerms: []
        }, {
            title: "bi bi-music-note-beamed",
            searchTerms: []
        }, {
            title: "bi bi-music-note-list",
            searchTerms: []
        }, {
            title: "bi bi-music-player",
            searchTerms: []
        }, {
            title: "bi bi-music-player-fill",
            searchTerms: []
        }, {
            title: "bi bi-newspaper",
            searchTerms: []
        }, {
            title: "bi bi-node-minus",
            searchTerms: []
        }, {
            title: "bi bi-node-minus-fill",
            searchTerms: []
        }, {
            title: "bi bi-node-plus",
            searchTerms: []
        }, {
            title: "bi bi-node-plus-fill",
            searchTerms: []
        }, {
            title: "bi bi-nut",
            searchTerms: []
        }, {
            title: "bi bi-nut-fill",
            searchTerms: []
        }, {
            title: "bi bi-octagon",
            searchTerms: []
        }, {
            title: "bi bi-octagon-fill",
            searchTerms: []
        }, {
            title: "bi bi-octagon-half",
            searchTerms: []
        }, {
            title: "bi bi-option",
            searchTerms: []
        }, {
            title: "bi bi-outlet",
            searchTerms: []
        }, {
            title: "bi bi-paint-bucket",
            searchTerms: []
        }, {
            title: "bi bi-palette",
            searchTerms: []
        }, {
            title: "bi bi-palette-fill",
            searchTerms: []
        }, {
            title: "bi bi-palette2",
            searchTerms: []
        }, {
            title: "bi bi-paperclip",
            searchTerms: []
        }, {
            title: "bi bi-paragraph",
            searchTerms: []
        }, {
            title: "bi bi-patch-check",
            searchTerms: []
        }, {
            title: "bi bi-patch-check-fill",
            searchTerms: []
        }, {
            title: "bi bi-patch-exclamation",
            searchTerms: []
        }, {
            title: "bi bi-patch-exclamation-fill",
            searchTerms: []
        }, {
            title: "bi bi-patch-minus",
            searchTerms: []
        }, {
            title: "bi bi-patch-minus-fill",
            searchTerms: []
        }, {
            title: "bi bi-patch-plus",
            searchTerms: []
        }, {
            title: "bi bi-patch-plus-fill",
            searchTerms: []
        }, {
            title: "bi bi-patch-question",
            searchTerms: []
        }, {
            title: "bi bi-patch-question-fill",
            searchTerms: []
        }, {
            title: "bi bi-pause",
            searchTerms: []
        }, {
            title: "bi bi-pause-btn",
            searchTerms: []
        }, {
            title: "bi bi-pause-btn-fill",
            searchTerms: []
        }, {
            title: "bi bi-pause-circle",
            searchTerms: []
        }, {
            title: "bi bi-pause-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-pause-fill",
            searchTerms: []
        }, {
            title: "bi bi-peace",
            searchTerms: []
        }, {
            title: "bi bi-peace-fill",
            searchTerms: []
        }, {
            title: "bi bi-pen",
            searchTerms: []
        }, {
            title: "bi bi-pen-fill",
            searchTerms: []
        }, {
            title: "bi bi-pencil",
            searchTerms: []
        }, {
            title: "bi bi-pencil-fill",
            searchTerms: []
        }, {
            title: "bi bi-pencil-square",
            searchTerms: []
        }, {
            title: "bi bi-pentagon",
            searchTerms: []
        }, {
            title: "bi bi-pentagon-fill",
            searchTerms: []
        }, {
            title: "bi bi-pentagon-half",
            searchTerms: []
        }, {
            title: "bi bi-people",
            searchTerms: []
        }, {
            title: "bi bi-person-circle",
            searchTerms: []
        }, {
            title: "bi bi-people-fill",
            searchTerms: []
        }, {
            title: "bi bi-percent",
            searchTerms: []
        }, {
            title: "bi bi-person",
            searchTerms: []
        }, {
            title: "bi bi-person-badge",
            searchTerms: []
        }, {
            title: "bi bi-person-badge-fill",
            searchTerms: []
        }, {
            title: "bi bi-person-bounding-box",
            searchTerms: []
        }, {
            title: "bi bi-person-check",
            searchTerms: []
        }, {
            title: "bi bi-person-check-fill",
            searchTerms: []
        }, {
            title: "bi bi-person-dash",
            searchTerms: []
        }, {
            title: "bi bi-person-dash-fill",
            searchTerms: []
        }, {
            title: "bi bi-person-fill",
            searchTerms: []
        }, {
            title: "bi bi-person-lines-fill",
            searchTerms: []
        }, {
            title: "bi bi-person-plus",
            searchTerms: []
        }, {
            title: "bi bi-person-plus-fill",
            searchTerms: []
        }, {
            title: "bi bi-person-square",
            searchTerms: []
        }, {
            title: "bi bi-person-x",
            searchTerms: []
        }, {
            title: "bi bi-person-x-fill",
            searchTerms: []
        }, {
            title: "bi bi-phone",
            searchTerms: []
        }, {
            title: "bi bi-phone-fill",
            searchTerms: []
        }, {
            title: "bi bi-phone-landscape",
            searchTerms: []
        }, {
            title: "bi bi-phone-landscape-fill",
            searchTerms: []
        }, {
            title: "bi bi-phone-vibrate",
            searchTerms: []
        }, {
            title: "bi bi-phone-vibrate-fill",
            searchTerms: []
        }, {
            title: "bi bi-pie-chart",
            searchTerms: []
        }, {
            title: "bi bi-pie-chart-fill",
            searchTerms: []
        }, {
            title: "bi bi-piggy-bank",
            searchTerms: []
        }, {
            title: "bi bi-piggy-bank-fill",
            searchTerms: []
        }, {
            title: "bi bi-pin",
            searchTerms: []
        }, {
            title: "bi bi-pin-angle",
            searchTerms: []
        }, {
            title: "bi bi-pin-angle-fill",
            searchTerms: []
        }, {
            title: "bi bi-pin-fill",
            searchTerms: []
        }, {
            title: "bi bi-pin-map",
            searchTerms: []
        }, {
            title: "bi bi-pin-map-fill",
            searchTerms: []
        }, {
            title: "bi bi-pip",
            searchTerms: []
        }, {
            title: "bi bi-pip-fill",
            searchTerms: []
        }, {
            title: "bi bi-play",
            searchTerms: []
        }, {
            title: "bi bi-play-btn",
            searchTerms: []
        }, {
            title: "bi bi-play-btn-fill",
            searchTerms: []
        }, {
            title: "bi bi-play-circle",
            searchTerms: []
        }, {
            title: "bi bi-play-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-play-fill",
            searchTerms: []
        }, {
            title: "bi bi-plug",
            searchTerms: []
        }, {
            title: "bi bi-plug-fill",
            searchTerms: []
        }, {
            title: "bi bi-plus",
            searchTerms: []
        }, {
            title: "bi bi-plus-circle",
            searchTerms: []
        }, {
            title: "bi bi-plus-circle-dotted",
            searchTerms: []
        }, {
            title: "bi bi-plus-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-plus-lg",
            searchTerms: []
        }, {
            title: "bi bi-plus-square",
            searchTerms: []
        }, {
            title: "bi bi-plus-square-dotted",
            searchTerms: []
        }, {
            title: "bi bi-plus-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-power",
            searchTerms: []
        }, {
            title: "bi bi-printer",
            searchTerms: []
        }, {
            title: "bi bi-printer-fill",
            searchTerms: []
        }, {
            title: "bi bi-puzzle",
            searchTerms: []
        }, {
            title: "bi bi-puzzle-fill",
            searchTerms: []
        }, {
            title: "bi bi-question",
            searchTerms: []
        }, {
            title: "bi bi-question-circle",
            searchTerms: []
        }, {
            title: "bi bi-question-diamond",
            searchTerms: []
        }, {
            title: "bi bi-question-diamond-fill",
            searchTerms: []
        }, {
            title: "bi bi-question-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-question-lg",
            searchTerms: []
        }, {
            title: "bi bi-question-octagon",
            searchTerms: []
        }, {
            title: "bi bi-question-octagon-fill",
            searchTerms: []
        }, {
            title: "bi bi-question-square",
            searchTerms: []
        }, {
            title: "bi bi-question-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-rainbow",
            searchTerms: []
        }, {
            title: "bi bi-receipt",
            searchTerms: []
        }, {
            title: "bi bi-receipt-cutoff",
            searchTerms: []
        }, {
            title: "bi bi-reception-0",
            searchTerms: []
        }, {
            title: "bi bi-reception-1",
            searchTerms: []
        }, {
            title: "bi bi-reception-2",
            searchTerms: []
        }, {
            title: "bi bi-reception-3",
            searchTerms: []
        }, {
            title: "bi bi-reception-4",
            searchTerms: []
        }, {
            title: "bi bi-record",
            searchTerms: []
        }, {
            title: "bi bi-record-btn",
            searchTerms: []
        }, {
            title: "bi bi-record-btn-fill",
            searchTerms: []
        }, {
            title: "bi bi-record-circle",
            searchTerms: []
        }, {
            title: "bi bi-record-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-record-fill",
            searchTerms: []
        }, {
            title: "bi bi-record2",
            searchTerms: []
        }, {
            title: "bi bi-record2-fill",
            searchTerms: []
        }, {
            title: "bi bi-recycle",
            searchTerms: []
        }, {
            title: "bi bi-reddit",
            searchTerms: []
        }, {
            title: "bi bi-reply",
            searchTerms: []
        }, {
            title: "bi bi-reply-all",
            searchTerms: []
        }, {
            title: "bi bi-reply-all-fill",
            searchTerms: []
        }, {
            title: "bi bi-reply-fill",
            searchTerms: []
        }, {
            title: "bi bi-rss",
            searchTerms: []
        }, {
            title: "bi bi-rss-fill",
            searchTerms: []
        }, {
            title: "bi bi-rulers",
            searchTerms: []
        }, {
            title: "bi bi-safe",
            searchTerms: []
        }, {
            title: "bi bi-safe-fill",
            searchTerms: []
        }, {
            title: "bi bi-safe2",
            searchTerms: []
        }, {
            title: "bi bi-safe2-fill",
            searchTerms: []
        }, {
            title: "bi bi-save",
            searchTerms: []
        }, {
            title: "bi bi-save-fill",
            searchTerms: []
        }, {
            title: "bi bi-save2",
            searchTerms: []
        }, {
            title: "bi bi-save2-fill",
            searchTerms: []
        }, {
            title: "bi bi-scissors",
            searchTerms: []
        }, {
            title: "bi bi-screwdriver",
            searchTerms: []
        }, {
            title: "bi bi-sd-card",
            searchTerms: []
        }, {
            title: "bi bi-sd-card-fill",
            searchTerms: []
        }, {
            title: "bi bi-search",
            searchTerms: []
        }, {
            title: "bi bi-segmented-nav",
            searchTerms: []
        }, {
            title: "bi bi-server",
            searchTerms: []
        }, {
            title: "bi bi-share",
            searchTerms: []
        }, {
            title: "bi bi-share-fill",
            searchTerms: []
        }, {
            title: "bi bi-shield",
            searchTerms: []
        }, {
            title: "bi bi-shield-check",
            searchTerms: []
        }, {
            title: "bi bi-shield-exclamation",
            searchTerms: []
        }, {
            title: "bi bi-shield-fill",
            searchTerms: []
        }, {
            title: "bi bi-shield-fill-check",
            searchTerms: []
        }, {
            title: "bi bi-shield-fill-exclamation",
            searchTerms: []
        }, {
            title: "bi bi-shield-fill-minus",
            searchTerms: []
        }, {
            title: "bi bi-shield-fill-plus",
            searchTerms: []
        }, {
            title: "bi bi-shield-fill-x",
            searchTerms: []
        }, {
            title: "bi bi-shield-lock",
            searchTerms: []
        }, {
            title: "bi bi-shield-lock-fill",
            searchTerms: []
        }, {
            title: "bi bi-shield-minus",
            searchTerms: []
        }, {
            title: "bi bi-shield-plus",
            searchTerms: []
        }, {
            title: "bi bi-shield-shaded",
            searchTerms: []
        }, {
            title: "bi bi-shield-slash",
            searchTerms: []
        }, {
            title: "bi bi-shield-slash-fill",
            searchTerms: []
        }, {
            title: "bi bi-shield-x",
            searchTerms: []
        }, {
            title: "bi bi-shift",
            searchTerms: []
        }, {
            title: "bi bi-shift-fill",
            searchTerms: []
        }, {
            title: "bi bi-shop",
            searchTerms: []
        }, {
            title: "bi bi-shop-window",
            searchTerms: []
        }, {
            title: "bi bi-shuffle",
            searchTerms: []
        }, {
            title: "bi bi-signpost",
            searchTerms: []
        }, {
            title: "bi bi-signpost-2",
            searchTerms: []
        }, {
            title: "bi bi-signpost-2-fill",
            searchTerms: []
        }, {
            title: "bi bi-signpost-fill",
            searchTerms: []
        }, {
            title: "bi bi-signpost-split",
            searchTerms: []
        }, {
            title: "bi bi-signpost-split-fill",
            searchTerms: []
        }, {
            title: "bi bi-sim",
            searchTerms: []
        }, {
            title: "bi bi-sim-fill",
            searchTerms: []
        }, {
            title: "bi bi-skip-backward",
            searchTerms: []
        }, {
            title: "bi bi-skip-backward-btn",
            searchTerms: []
        }, {
            title: "bi bi-skip-backward-btn-fill",
            searchTerms: []
        }, {
            title: "bi bi-skip-backward-circle",
            searchTerms: []
        }, {
            title: "bi bi-skip-backward-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-skip-backward-fill",
            searchTerms: []
        }, {
            title: "bi bi-skip-end",
            searchTerms: []
        }, {
            title: "bi bi-skip-end-btn",
            searchTerms: []
        }, {
            title: "bi bi-skip-end-btn-fill",
            searchTerms: []
        }, {
            title: "bi bi-skip-end-circle",
            searchTerms: []
        }, {
            title: "bi bi-skip-end-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-skip-end-fill",
            searchTerms: []
        }, {
            title: "bi bi-skip-forward",
            searchTerms: []
        }, {
            title: "bi bi-skip-forward-btn",
            searchTerms: []
        }, {
            title: "bi bi-skip-forward-btn-fill",
            searchTerms: []
        }, {
            title: "bi bi-skip-forward-circle",
            searchTerms: []
        }, {
            title: "bi bi-skip-forward-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-skip-forward-fill",
            searchTerms: []
        }, {
            title: "bi bi-skip-start",
            searchTerms: []
        }, {
            title: "bi bi-skip-start-btn",
            searchTerms: []
        }, {
            title: "bi bi-skip-start-btn-fill",
            searchTerms: []
        }, {
            title: "bi bi-skip-start-circle",
            searchTerms: []
        }, {
            title: "bi bi-skip-start-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-skip-start-fill",
            searchTerms: []
        }, {
            title: "bi bi-skype",
            searchTerms: []
        }, {
            title: "bi bi-slack",
            searchTerms: []
        }, {
            title: "bi bi-slash",
            searchTerms: []
        }, {
            title: "bi bi-slash-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-slash-lg",
            searchTerms: []
        }, {
            title: "bi bi-slash-square",
            searchTerms: []
        }, {
            title: "bi bi-slash-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-sliders",
            searchTerms: []
        }, {
            title: "bi bi-smartwatch",
            searchTerms: []
        }, {
            title: "bi bi-snow",
            searchTerms: []
        }, {
            title: "bi bi-snow2",
            searchTerms: []
        }, {
            title: "bi bi-snow3",
            searchTerms: []
        }, {
            title: "bi bi-sort-alpha-down",
            searchTerms: []
        }, {
            title: "bi bi-sort-alpha-down-alt",
            searchTerms: []
        }, {
            title: "bi bi-sort-alpha-up",
            searchTerms: []
        }, {
            title: "bi bi-sort-alpha-up-alt",
            searchTerms: []
        }, {
            title: "bi bi-sort-down",
            searchTerms: []
        }, {
            title: "bi bi-sort-down-alt",
            searchTerms: []
        }, {
            title: "bi bi-sort-numeric-down",
            searchTerms: []
        }, {
            title: "bi bi-sort-numeric-down-alt",
            searchTerms: []
        }, {
            title: "bi bi-sort-numeric-up",
            searchTerms: []
        }, {
            title: "bi bi-sort-numeric-up-alt",
            searchTerms: []
        }, {
            title: "bi bi-sort-up",
            searchTerms: []
        }, {
            title: "bi bi-sort-up-alt",
            searchTerms: []
        }, {
            title: "bi bi-soundwave",
            searchTerms: []
        }, {
            title: "bi bi-speaker",
            searchTerms: []
        }, {
            title: "bi bi-speaker-fill",
            searchTerms: []
        }, {
            title: "bi bi-speedometer",
            searchTerms: []
        }, {
            title: "bi bi-speedometer2",
            searchTerms: []
        }, {
            title: "bi bi-spellcheck",
            searchTerms: []
        }, {
            title: "bi bi-square",
            searchTerms: []
        }, {
            title: "bi bi-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-square-half",
            searchTerms: []
        }, {
            title: "bi bi-stack",
            searchTerms: []
        }, {
            title: "bi bi-star",
            searchTerms: []
        }, {
            title: "bi bi-star-fill",
            searchTerms: []
        }, {
            title: "bi bi-star-half",
            searchTerms: []
        }, {
            title: "bi bi-stars",
            searchTerms: []
        }, {
            title: "bi bi-stickies",
            searchTerms: []
        }, {
            title: "bi bi-stickies-fill",
            searchTerms: []
        }, {
            title: "bi bi-sticky",
            searchTerms: []
        }, {
            title: "bi bi-sticky-fill",
            searchTerms: []
        }, {
            title: "bi bi-stop",
            searchTerms: []
        }, {
            title: "bi bi-stop-btn",
            searchTerms: []
        }, {
            title: "bi bi-stop-btn-fill",
            searchTerms: []
        }, {
            title: "bi bi-stop-circle",
            searchTerms: []
        }, {
            title: "bi bi-stop-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-stop-fill",
            searchTerms: []
        }, {
            title: "bi bi-stoplights",
            searchTerms: []
        }, {
            title: "bi bi-stoplights-fill",
            searchTerms: []
        }, {
            title: "bi bi-stopwatch",
            searchTerms: []
        }, {
            title: "bi bi-stopwatch-fill",
            searchTerms: []
        }, {
            title: "bi bi-subtract",
            searchTerms: []
        }, {
            title: "bi bi-suit-club",
            searchTerms: []
        }, {
            title: "bi bi-suit-club-fill",
            searchTerms: []
        }, {
            title: "bi bi-suit-diamond",
            searchTerms: []
        }, {
            title: "bi bi-suit-diamond-fill",
            searchTerms: []
        }, {
            title: "bi bi-suit-heart",
            searchTerms: []
        }, {
            title: "bi bi-suit-heart-fill",
            searchTerms: []
        }, {
            title: "bi bi-suit-spade",
            searchTerms: []
        }, {
            title: "bi bi-suit-spade-fill",
            searchTerms: []
        }, {
            title: "bi bi-sun",
            searchTerms: []
        }, {
            title: "bi bi-sun-fill",
            searchTerms: []
        }, {
            title: "bi bi-sunglasses",
            searchTerms: []
        }, {
            title: "bi bi-sunrise",
            searchTerms: []
        }, {
            title: "bi bi-sunrise-fill",
            searchTerms: []
        }, {
            title: "bi bi-sunset",
            searchTerms: []
        }, {
            title: "bi bi-sunset-fill",
            searchTerms: []
        }, {
            title: "bi bi-symmetry-horizontal",
            searchTerms: []
        }, {
            title: "bi bi-symmetry-vertical",
            searchTerms: []
        }, {
            title: "bi bi-table",
            searchTerms: []
        }, {
            title: "bi bi-tablet",
            searchTerms: []
        }, {
            title: "bi bi-tablet-fill",
            searchTerms: []
        }, {
            title: "bi bi-tablet-landscape",
            searchTerms: []
        }, {
            title: "bi bi-tablet-landscape-fill",
            searchTerms: []
        }, {
            title: "bi bi-tag",
            searchTerms: []
        }, {
            title: "bi bi-tag-fill",
            searchTerms: []
        }, {
            title: "bi bi-tags",
            searchTerms: []
        }, {
            title: "bi bi-tags-fill",
            searchTerms: []
        }, {
            title: "bi bi-telegram",
            searchTerms: []
        }, {
            title: "bi bi-telephone",
            searchTerms: []
        }, {
            title: "bi bi-telephone-fill",
            searchTerms: []
        }, {
            title: "bi bi-telephone-forward",
            searchTerms: []
        }, {
            title: "bi bi-telephone-forward-fill",
            searchTerms: []
        }, {
            title: "bi bi-telephone-inbound",
            searchTerms: []
        }, {
            title: "bi bi-telephone-inbound-fill",
            searchTerms: []
        }, {
            title: "bi bi-telephone-minus",
            searchTerms: []
        }, {
            title: "bi bi-telephone-minus-fill",
            searchTerms: []
        }, {
            title: "bi bi-telephone-outbound",
            searchTerms: []
        }, {
            title: "bi bi-telephone-outbound-fill",
            searchTerms: []
        }, {
            title: "bi bi-telephone-plus",
            searchTerms: []
        }, {
            title: "bi bi-telephone-plus-fill",
            searchTerms: []
        }, {
            title: "bi bi-telephone-x",
            searchTerms: []
        }, {
            title: "bi bi-telephone-x-fill",
            searchTerms: []
        }, {
            title: "bi bi-terminal",
            searchTerms: []
        }, {
            title: "bi bi-terminal-fill",
            searchTerms: []
        }, {
            title: "bi bi-text-center",
            searchTerms: []
        }, {
            title: "bi bi-text-indent-left",
            searchTerms: []
        }, {
            title: "bi bi-text-indent-right",
            searchTerms: []
        }, {
            title: "bi bi-text-left",
            searchTerms: []
        }, {
            title: "bi bi-text-paragraph",
            searchTerms: []
        }, {
            title: "bi bi-text-right",
            searchTerms: []
        }, {
            title: "bi bi-textarea",
            searchTerms: []
        }, {
            title: "bi bi-textarea-resize",
            searchTerms: []
        }, {
            title: "bi bi-textarea-t",
            searchTerms: []
        }, {
            title: "bi bi-thermometer",
            searchTerms: []
        }, {
            title: "bi bi-thermometer-half",
            searchTerms: []
        }, {
            title: "bi bi-thermometer-high",
            searchTerms: []
        }, {
            title: "bi bi-thermometer-low",
            searchTerms: []
        }, {
            title: "bi bi-thermometer-snow",
            searchTerms: []
        }, {
            title: "bi bi-thermometer-sun",
            searchTerms: []
        }, {
            title: "bi bi-three-dots",
            searchTerms: []
        }, {
            title: "bi bi-three-dots-vertical",
            searchTerms: []
        }, {
            title: "bi bi-toggle-off",
            searchTerms: []
        }, {
            title: "bi bi-toggle-on",
            searchTerms: []
        }, {
            title: "bi bi-toggle2-off",
            searchTerms: []
        }, {
            title: "bi bi-toggle2-on",
            searchTerms: []
        }, {
            title: "bi bi-toggles",
            searchTerms: []
        }, {
            title: "bi bi-toggles2",
            searchTerms: []
        }, {
            title: "bi bi-tools",
            searchTerms: []
        }, {
            title: "bi bi-tornado",
            searchTerms: []
        }, {
            title: "bi bi-translate",
            searchTerms: []
        }, {
            title: "bi bi-trash",
            searchTerms: []
        }, {
            title: "bi bi-trash-fill",
            searchTerms: []
        }, {
            title: "bi bi-trash2",
            searchTerms: []
        }, {
            title: "bi bi-trash2-fill",
            searchTerms: []
        }, {
            title: "bi bi-tree",
            searchTerms: []
        }, {
            title: "bi bi-tree-fill",
            searchTerms: []
        }, {
            title: "bi bi-triangle",
            searchTerms: []
        }, {
            title: "bi bi-triangle-fill",
            searchTerms: []
        }, {
            title: "bi bi-triangle-half",
            searchTerms: []
        }, {
            title: "bi bi-trophy",
            searchTerms: []
        }, {
            title: "bi bi-trophy-fill",
            searchTerms: []
        }, {
            title: "bi bi-tropical-storm",
            searchTerms: []
        }, {
            title: "bi bi-truck",
            searchTerms: []
        }, {
            title: "bi bi-truck-flatbed",
            searchTerms: []
        }, {
            title: "bi bi-tsunami",
            searchTerms: []
        }, {
            title: "bi bi-tv",
            searchTerms: []
        }, {
            title: "bi bi-tv-fill",
            searchTerms: []
        }, {
            title: "bi bi-twitch",
            searchTerms: []
        }, {
            title: "bi bi-twitter",
            searchTerms: []
        }, {
            title: "bi bi-type",
            searchTerms: []
        }, {
            title: "bi bi-type-bold",
            searchTerms: []
        }, {
            title: "bi bi-type-h1",
            searchTerms: []
        }, {
            title: "bi bi-type-h2",
            searchTerms: []
        }, {
            title: "bi bi-type-h3",
            searchTerms: []
        }, {
            title: "bi bi-type-italic",
            searchTerms: []
        }, {
            title: "bi bi-type-strikethrough",
            searchTerms: []
        }, {
            title: "bi bi-type-underline",
            searchTerms: []
        }, {
            title: "bi bi-ui-checks",
            searchTerms: []
        }, {
            title: "bi bi-ui-checks-grid",
            searchTerms: []
        }, {
            title: "bi bi-ui-radios",
            searchTerms: []
        }, {
            title: "bi bi-ui-radios-grid",
            searchTerms: []
        }, {
            title: "bi bi-umbrella",
            searchTerms: []
        }, {
            title: "bi bi-umbrella-fill",
            searchTerms: []
        }, {
            title: "bi bi-union",
            searchTerms: []
        }, {
            title: "bi bi-unlock",
            searchTerms: []
        }, {
            title: "bi bi-unlock-fill",
            searchTerms: []
        }, {
            title: "bi bi-upc",
            searchTerms: []
        }, {
            title: "bi bi-upc-scan",
            searchTerms: []
        }, {
            title: "bi bi-upload",
            searchTerms: []
        }, {
            title: "bi bi-vector-pen",
            searchTerms: []
        }, {
            title: "bi bi-view-list",
            searchTerms: []
        }, {
            title: "bi bi-view-stacked",
            searchTerms: []
        }, {
            title: "bi bi-vinyl",
            searchTerms: []
        }, {
            title: "bi bi-vinyl-fill",
            searchTerms: []
        }, {
            title: "bi bi-voicemail",
            searchTerms: []
        }, {
            title: "bi bi-volume-down",
            searchTerms: []
        }, {
            title: "bi bi-volume-down-fill",
            searchTerms: []
        }, {
            title: "bi bi-volume-mute",
            searchTerms: []
        }, {
            title: "bi bi-volume-mute-fill",
            searchTerms: []
        }, {
            title: "bi bi-volume-off",
            searchTerms: []
        }, {
            title: "bi bi-volume-off-fill",
            searchTerms: []
        }, {
            title: "bi bi-volume-up",
            searchTerms: []
        }, {
            title: "bi bi-volume-up-fill",
            searchTerms: []
        }, {
            title: "bi bi-vr",
            searchTerms: []
        }, {
            title: "bi bi-wallet",
            searchTerms: []
        }, {
            title: "bi bi-wallet-fill",
            searchTerms: []
        }, {
            title: "bi bi-wallet2",
            searchTerms: []
        }, {
            title: "bi bi-watch",
            searchTerms: []
        }, {
            title: "bi bi-water",
            searchTerms: []
        }, {
            title: "bi bi-whatsapp",
            searchTerms: []
        }, {
            title: "bi bi-wifi",
            searchTerms: []
        }, {
            title: "bi bi-wifi-1",
            searchTerms: []
        }, {
            title: "bi bi-wifi-2",
            searchTerms: []
        }, {
            title: "bi bi-wifi-off",
            searchTerms: []
        }, {
            title: "bi bi-wind",
            searchTerms: []
        }, {
            title: "bi bi-window",
            searchTerms: []
        }, {
            title: "bi bi-window-dock",
            searchTerms: []
        }, {
            title: "bi bi-window-sidebar",
            searchTerms: []
        }, {
            title: "bi bi-wrench",
            searchTerms: []
        }, {
            title: "bi bi-x",
            searchTerms: []
        }, {
            title: "bi bi-x-circle",
            searchTerms: []
        }, {
            title: "bi bi-x-circle-fill",
            searchTerms: []
        }, {
            title: "bi bi-x-diamond",
            searchTerms: []
        }, {
            title: "bi bi-x-diamond-fill",
            searchTerms: []
        }, {
            title: "bi bi-x-lg",
            searchTerms: []
        }, {
            title: "bi bi-x-octagon",
            searchTerms: []
        }, {
            title: "bi bi-x-octagon-fill",
            searchTerms: []
        }, {
            title: "bi bi-x-square",
            searchTerms: []
        }, {
            title: "bi bi-x-square-fill",
            searchTerms: []
        }, {
            title: "bi bi-youtube",
            searchTerms: []
        }, {
            title: "bi bi-zoom-in",
            searchTerms: []
        }, {
            title: "bi bi-zoom-out",
            searchTerms: []
        }]
    });
});